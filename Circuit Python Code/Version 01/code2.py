import time
import board
import busio
import digitalio

import displayio
import terminalio
from adafruit_display_text import label

# Import the SSD1306 module.
import adafruit_ssd1306

# Import the INA219 module.
import adafruit_ina219


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


def update_display(disp, test):
    disp.fill(0)
    disp.show()

    if test == "\\":
        # Set a pixel in the origin 0,0 position.
        disp.pixel(0, 0, 1)
        # Set a pixel in the middle 64, 16 position.
        disp.pixel(64, 31, 1)
        # Set a pixel in the opposite 127, 31 position.
        disp.pixel(127, 63, 1)
    elif test == "/":
        # Set a pixel in the origin 0,0 position.
        disp.pixel(127, 0, 1)
        # Set a pixel in the middle 64, 16 position.
        disp.pixel(64, 31, 1)
        # Set a pixel in the opposite 127, 31 position.
        disp.pixel(0, 63, 1)
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

# Make the display context
# splash_0 = oled_0.Group()
# splash_1 = oled_1.Group()

oled_test_1 = True
displayPreviousTime = time.monotonic()
displayInterval = 0.2    # Time in seconds

update_display(oled_0, "\\")
update_display(oled_1, "/")

powerPreviousTime = time.monotonic()
powerInterval = 0.2    # Time in seconds

oled_0

# Print data headers
print("H\tTIME\tVIN_IN_1\tVIN_OUT_1\tShuntV_1\tShuntC_1\tPowerCal_1\tPowerRegister_1\tVIN_IN_2\tVIN_OUT_2\tShuntV_2\tShuntC_2\tPowerCal_2\tPowerRegister_2")

while True:
    if time.monotonic() - displayPreviousTime >= displayInterval:
        displayPreviousTime = time.monotonic()

        if oled_test_1:
            update_display(oled_0, "/")
            update_display(oled_1, "\\")
        else:
            update_display(oled_0, "\\")
            update_display(oled_1, "/")

        oled_test_1 = not oled_test_1

    if time.monotonic() - powerPreviousTime >= powerInterval:
        powerPreviousTime = time.monotonic()

        meter_0 = get_ina219_info(ina219_0)
        meter_1 = get_ina219_info(ina219_1)

        # print("VIN_IN_1\tVIN_OUT_1\tShuntV_1\tShuntC_1\tPowerCal_1\tPowerRegister_1\tVIN_IN_2\tVIN_OUT_2\tShuntV_2\tShuntC_2\tPowerCal_2\tPowerRegister_2")
        print(("P\t{:.3f}\t{:.3f}\t{:.3f}\t{:.5f}\t{:.4f}\t{:.5f}\t{:.3f}\t{:.3f}" +
               "\t{:.3f}\t{:.5f}\t{:.4f}\t{:.5f}\t{:.3f}").format(displayPreviousTime,
                                                                  meter_0["VIN_IN"], meter_0["VIN_OUT"], meter_0["ShuntV"], meter_0["ShuntC"],
                                                                  meter_0["PowerCal"], meter_0["PowerRegister"],
                                                                  meter_1["VIN_IN"], meter_1["VIN_OUT"], meter_1["ShuntV"], meter_1["ShuntC"],
                                                                  meter_1["PowerCal"], meter_1["PowerRegister"]))
