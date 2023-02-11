import time
import board
import busio
import digitalio
import displayio
import json

# Import the SSD1306 module.
import adafruit_ssd1306

# Import the INA219 module.
import adafruit_ina219


def display_text(disp, txt, pos_char, pos_line, color):
    x = int((pos_char) * pixels_char_w)
    y = int((pos_line) * pixels_char_h)

    disp.text(txt, x, y, color)


def get_ina219_info(meter):
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


def update_display(disp, ina219_info):
    if ina219_info is None:
        disp.fill(1)
        display_text(disp, "Channel", 7, 2, 0)
        display_text(disp, "v0.1: 5 February 2023", 0, 5, 0)
        # disp.text("Channel", 42, 20, 0)
        if disp == oled_0:
            display_text(disp, "One", 9, 3, 0)
        else:
            display_text(disp, "Two", 9, 3, 0)

        disp.show()

        return

    disp.fill(0)

    display_text(
        disp, "    V-In:  {:6.3f}   V".format(ina219_info["VIN_IN"]), 0, 0, 1)
    display_text(
        disp, "   V-Out:  {:6.3f}   V".format(ina219_info["VIN_OUT"]), 0, 1, 1)
    display_text(
        disp, " V-Shunt:  {:8.5f} V".format(ina219_info["ShuntV"]), 0, 2, 1)
    display_text(
        disp, " I-Shunt: {:7.3f}   A".format(ina219_info["ShuntC"]), 0, 3, 1)
    display_text(
        disp, "Powr-Cal:  {:8.5f} W".format(ina219_info["PowerCal"]), 0, 4, 1)
    display_text(disp, "   Power:  {:6.3f}   W".format(
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
displayInterval = 0.02    # Time in seconds

update_display(oled_0, None)
update_display(oled_1, None)
time.sleep(3)

powerPreviousTime = time.monotonic()
powerInterval = 0.01    # Time in seconds

oled_0

meter_0 = get_ina219_info(ina219_0)
meter_1 = get_ina219_info(ina219_1)

while True:
    if time.monotonic() - displayPreviousTime >= displayInterval:
        displayPreviousTime = time.monotonic()

        update_display(oled_0, meter_0)
        update_display(oled_1, meter_1)

    if time.monotonic() - powerPreviousTime >= powerInterval:
        powerPreviousTime = time.monotonic()

        meter_0_time = time.monotonic()
        meter_0 = get_ina219_info(ina219_0)
        meter_1_time = time.monotonic()
        meter_1 = get_ina219_info(ina219_1)

        print(json.dumps({"time": displayPreviousTime, "channel_1": meter_0, "channel_2": meter_1}))
        # print("{:0.8f}\t{:0.8f}".format(time.monotonic(), meter_1_time - meter_0_time))
