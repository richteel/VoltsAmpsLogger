# SPDX-FileCopyrightText: Tony DiCola
# SPDX-License-Identifier: CC0-1.0

# Basic example of clearing and drawing pixels on a SSD1306 OLED display.
# This example and library is meant to work with Adafruit CircuitPython API.

# Import all board pins.
import time
import board
import busio
import digitalio

# Import the SSD1306 module.
import adafruit_ssd1306

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

print("START")

# Create the I2C interface.
i2c0 = busio.I2C(board.GP15, board.GP14, frequency=400_000)
i2c1 = busio.I2C(board.GP17, board.GP16, frequency=400_000)

# Create the SSD1306 OLED class.
# The first two parameters are the pixel width and pixel height.  Change these
# to the right size for your display!
# See https://forums.adafruit.com/viewtopic.php?f=47&p=764328 for reset issue workaround
oled0 = adafruit_ssd1306.SSD1306_I2C(width=128, height=64, i2c=i2c0, reset=digitalio.DigitalInOut(board.GP13), addr=0x3d)
oled1 = adafruit_ssd1306.SSD1306_I2C(width=128, height=64, i2c=i2c1, reset=digitalio.DigitalInOut(board.GP18), addr=0x3d)
# Alternatively you can change the I2C address of the device with an addr parameter:
# display = adafruit_ssd1306.SSD1306_I2C(128, 32, i2c, addr=0x31)

# Clear the display.  Always call show after changing pixels to make the display
# update visible!

show1 = True

while True:
    if show1:
        test_display(oled0, "/")
        test_display(oled1, "\\")
    else:
        test_display(oled0, "\\")
        test_display(oled1, "/")

    show1 = not show1

    time.sleep(2)

print("DONE")