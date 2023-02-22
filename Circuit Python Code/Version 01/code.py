import time
import board
import busio
import digitalio
import displayio
import json
import usb_cdc

# Import the SSD1306 module.
import adafruit_ssd1306

# Import the INA219 module.
import adafruit_ina219

versionHW = "HW v0.1:  5 Feb 2023"
versionSW = "SW v0.1: 21 Feb 2023"


def display_text(disp, txt, pos_char, pos_line, color):
    x = int((pos_char) * pixels_char_w)
    y = int((pos_line) * pixels_char_h)

    disp.text(txt, x, y, color)


def get_ina219_data(meter):
    bus_voltage = meter.bus_voltage  # voltage on V- (load side)
    shunt_voltage = meter.shunt_voltage  # voltage between V+ and V- across the shunt
    current = meter.current  # current in mA
    power = meter.power  # power in watts

    return {"VIN_IN": (bus_voltage + shunt_voltage),
            "VIN_OUT": bus_voltage,
            "ShuntV": shunt_voltage,
            "ShuntC": (current / 1000),
            "PowerCal": (bus_voltage * (current / 1000)),
            "PowerRegister": power}

# REF: https://stackoverflow.com/questions/65647986/how-to-do-non-blocking-usb-serial-input-in-circuit-python


serialText = ""


def read_serial(serial):
    global serialText

    text = ""
    while serial.in_waiting:
        raw = serial.read(serial.in_waiting)
        text = raw.decode("utf-8")

    serialText += text

    if (len(serialText) > 0 and not serialText.startswith(".")):
        print("Discarded: {0}".format(serialText))
        serialText = ""

    if "\n" in serialText or "\r" in serialText:
        text = serialText.strip()
        serialText = ""
        return text

    return ""


CHANNEL_TEXT = "Channel"
ONE_TEXT = "One"
TWO_TEXT = "Two"
VIN_TEXT = "    V-In:  {:6.3f}   V"
VOUT_TEXT = "   V-Out:  {:6.3f}   V"
VSHUNT_TEXT = " V-Shunt:  {:8.5f} V"
ISHUNT_TEXT = " I-Shunt: {:7.3f}   A"
POWERCALC_TEXT = "Powr-Cal:  {:8.5f} W"
POWER_TEXT = "   Power:  {:6.3f}   W"


def update_display(disp, ina219_info, s=""):
    if ina219_info is None:
        disp.fill(1)
        if s == "":
            display_text(disp, CHANNEL_TEXT, 7, 2, 0)
            display_text(disp, versionHW, 0, 4, 0)
            display_text(disp, versionSW, 0, 5, 0)
            if disp == oled_0:
                display_text(disp, ONE_TEXT, 9, 3, 0)
            else:
                display_text(disp, TWO_TEXT, 9, 3, 0)
        else:
            display_text(disp, s, 0, 3, 0)

        disp.show()

        return

    disp.fill(0)

    display_text(
        disp, VIN_TEXT.format(ina219_info["VIN_IN"]), 0, 0, 1)
    display_text(
        disp, VOUT_TEXT.format(ina219_info["VIN_OUT"]), 0, 1, 1)
    display_text(
        disp, VSHUNT_TEXT.format(ina219_info["ShuntV"]), 0, 2, 1)
    display_text(
        disp, ISHUNT_TEXT.format(ina219_info["ShuntC"]), 0, 3, 1)
    display_text(
        disp, POWERCALC_TEXT.format(ina219_info["PowerCal"]), 0, 4, 1)
    display_text(disp, POWER_TEXT.format(
        ina219_info["PowerRegister"]), 0, 5, 1)

    disp.show()


# ***** SETUP IC2 *****
i2c_0 = busio.I2C(board.GP15, board.GP14, frequency=400_000)
i2c_1 = busio.I2C(board.GP17, board.GP16, frequency=400_000)

# ***** SETUP INA219 *****
ina219_0 = adafruit_ina219.INA219(i2c_0)
ina219_1 = adafruit_ina219.INA219(i2c_1)

# 0.1 Ohm Resistor
ina219_0.set_calibration_16V_400mA()
ina219_1.set_calibration_16V_400mA()

# ***** SETUP DISPLAY *****
displayio.release_displays()

oled_0 = adafruit_ssd1306.SSD1306_I2C(
    width=128, height=64, i2c=i2c_0, reset=digitalio.DigitalInOut(board.GP13), addr=0x3d)
oled_1 = adafruit_ssd1306.SSD1306_I2C(
    width=128, height=64, i2c=i2c_1, reset=digitalio.DigitalInOut(board.GP18), addr=0x3d)

screen_w_chars = 21
screen_h_lines = 6

pixels_char_w = oled_0.width/screen_w_chars
pixels_char_h = oled_0.height/screen_h_lines

displayPreviousTime = time.monotonic()
displayIntervalDefault = 1.0  # Time in seconds
displayInterval = 0.01   # Time in seconds

update_display(oled_0, None)
update_display(oled_1, None)
time.sleep(3)

powerPreviousTime = time.monotonic()
powerIntervalDefault = 0.2  # Time in seconds
powerInterval = 0.01    # Time in seconds

meter_0 = get_ina219_data(ina219_0)
meter_1 = get_ina219_data(ina219_1)

output_json = True
delimited_char = '\t'
delformat = "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}"

display_enable = True
serial_enable = False

# print(usb_cdc.serials)

if usb_cdc.data is None:
    uart = usb_cdc.console
else:
    uart = usb_cdc.data

# uart.timeout = 0  # If 0, do not wait.

while True:
    in_lines = read_serial(uart).splitlines()
    for in_text in in_lines:
        if len(in_text) > 0:
            in_text = in_text.lower()
            print(f"RX: {in_text}")
            if in_text in (".so.", ".os.", ".s."):
                display_enable = False
                serial_enable = True
                powerInterval = 0.01
                update_display(oled_0, None, "     Serial Mode")
                update_display(oled_1, None, "     Serial Mode")
                print("Serial Only")
            elif in_text in (".sd.", ".ds."):
                display_enable = True
                serial_enable = True
                displayInterval = displayIntervalDefault
                powerInterval = powerIntervalDefault
                print("Serial & Display")
            elif in_text in (".do.", ".od.", ".d."):
                display_enable = True
                serial_enable = False
                displayInterval = 0.1
                print("Display Only")
            elif in_text in (".oo.", ".o."):
                display_enable = False
                serial_enable = False
                print("None - Stop")
            elif in_text == ".j.":
                output_json = True
                print("JSON Output")
            elif in_text == ".t.":
                output_json = False
                print("Text (Tab) Output")
            elif in_text == ".findmeter.":
                uart.write(bytearray((".METER-HERE.\r\n").encode()))
            elif in_text == ".v.":
                uart.write(
                    bytearray((f"{versionHW}\r\n{versionSW}\r\n".encode())))
            else:
                print(f"Unknown: {in_text}")

    if display_enable and time.monotonic() - displayPreviousTime >= displayInterval:
        displayPreviousTime = time.monotonic()
        if not serial_enable:
            meter_0_time = time.monotonic()
            meter_0 = get_ina219_data(ina219_0)
            meter_1_time = time.monotonic()
            meter_1 = get_ina219_data(ina219_1)

        update_display(oled_0, meter_0)
        update_display(oled_1, meter_1)

    if serial_enable and time.monotonic() - powerPreviousTime >= powerInterval:
        powerPreviousTime = time.monotonic()

        meter_0_time = time.monotonic()
        meter_0 = get_ina219_data(ina219_0)
        meter_1_time = time.monotonic()
        meter_1 = get_ina219_data(ina219_1)

        data = ""
        if output_json:
            data = json.dumps({"time": displayPreviousTime,
                              "channel_1": meter_0, "channel_2": meter_1})
        else:
            data = delformat.format(displayPreviousTime,
                                    meter_0["VIN_IN"], meter_0["VIN_OUT"], meter_0["ShuntV"],
                                    meter_0["ShuntC"], meter_0["PowerCal"], meter_0["PowerRegister"],
                                    meter_1["VIN_IN"], meter_1["VIN_OUT"], meter_1["ShuntV"],
                                    meter_1["ShuntC"], meter_1["PowerCal"], meter_1["PowerRegister"])

        uart.write(bytearray((data + "\r\n").encode()))
