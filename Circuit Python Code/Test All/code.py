import time
import board
import busio
import digitalio

# Import the SSD1306 module.
import adafruit_ssd1306

# Import the INA219 module.
import adafruit_ina219

def test_display(disp, test):
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
oled_0 = adafruit_ssd1306.SSD1306_I2C(width=128, height=64, i2c=i2c_0, reset=digitalio.DigitalInOut(board.GP13), addr=0x3d)
oled_1 = adafruit_ssd1306.SSD1306_I2C(width=128, height=64, i2c=i2c_1, reset=digitalio.DigitalInOut(board.GP18), addr=0x3d)

oled_test_1 = True
displayPreviousTime = time.monotonic()
displayInterval = 0.2    # Time in seconds

test_display(oled_0, "\\")
test_display(oled_1, "/")

powerPreviousTime = time.monotonic()
powerInterval = 0.2    # Time in seconds

# Print data headers
print("TIME\tVIN_IN_1\tVIN_OUT_1\tShuntV_1\tShuntC_1\tPowerCal_1\tPowerRegister_1\tVIN_IN_2\tVIN_OUT_2\tShuntV_2\tShuntC_2\tPowerCal_2\tPowerRegister_2")

while True:
    if time.monotonic() - displayPreviousTime >= displayInterval:
        displayPreviousTime = time.monotonic()

        if oled_test_1:
            test_display(oled_0, "/")
            test_display(oled_1, "\\")
        else:
            test_display(oled_0, "\\")
            test_display(oled_1, "/")

        oled_test_1 = not oled_test_1

    
    if time.monotonic() - powerPreviousTime >= powerInterval:
        powerPreviousTime = time.monotonic()

        bus_voltage_0 = ina219_0.bus_voltage  # voltage on V- (load side)
        shunt_voltage_0 = ina219_0.shunt_voltage  # voltage between V+ and V- across the shunt
        current_0 = ina219_0.current  # current in mA
        power_0 = ina219_0.power  # power in watts

        bus_voltage_1 = ina219_1.bus_voltage  # voltage on V- (load side)
        shunt_voltage_1 = ina219_1.shunt_voltage  # voltage between V+ and V- across the shunt
        current_1 = ina219_1.current  # current in mA
        power_1 = ina219_1.power  # power in watts

        print(("{:.3f}\t{:.3f}\t{:.3f}\t{:.5f}\t{:.4f}\t{:.5f}\t{:.3f}\t{:.3f}" +
                    "\t{:.3f}\t{:.5f}\t{:.4f}\t{:.5f}\t{:.3f}").format( displayPreviousTime,
                                                                        (bus_voltage_0 + shunt_voltage_0), bus_voltage_0, shunt_voltage_0, (current_0 / 1000), 
                                                                        (bus_voltage_0 * (current_0 / 1000)), power_0,  
                                                                        (bus_voltage_1 + shunt_voltage_1), bus_voltage_1, shunt_voltage_1, (current_1 / 1000), 
                                                                        (bus_voltage_1 * (current_1 / 1000)), power_1))

