import time
import board
import busio
import adafruit_ina219

# Create the I2C interface.
i2c0 = busio.I2C(board.GP15, board.GP14, frequency=400_000)
i2c1 = busio.I2C(board.GP17, board.GP16, frequency=400_000)

ina219_0 = adafruit_ina219.INA219(i2c0)
ina219_1 = adafruit_ina219.INA219(i2c1)

print("ina219 test")

# display some of the advanced field (just to test)
print("Config register Channel 1:")
print("  bus_voltage_range:    0x%1X" % ina219_0.bus_voltage_range)
print("  gain:                 0x%1X" % ina219_0.gain)
print("  bus_adc_resolution:   0x%1X" % ina219_0.bus_adc_resolution)
print("  shunt_adc_resolution: 0x%1X" % ina219_0.shunt_adc_resolution)
print("  mode:                 0x%1X" % ina219_0.mode)
print("")

# display some of the advanced field (just to test)
print("Config register Channel 2:")
print("  bus_voltage_range:    0x%1X" % ina219_1.bus_voltage_range)
print("  gain:                 0x%1X" % ina219_1.gain)
print("  bus_adc_resolution:   0x%1X" % ina219_1.bus_adc_resolution)
print("  shunt_adc_resolution: 0x%1X" % ina219_1.shunt_adc_resolution)
print("  mode:                 0x%1X" % ina219_1.mode)
print("")

# optional : change configuration to use 32 samples averaging for both bus voltage and shunt voltage
ina219_0.bus_adc_resolution = adafruit_ina219.ADCResolution.ADCRES_12BIT_32S
ina219_0.shunt_adc_resolution = adafruit_ina219.ADCResolution.ADCRES_12BIT_32S
# optional : change voltage range to 16V
ina219_0.bus_voltage_range = adafruit_ina219.BusVoltageRange.RANGE_16V

# optional : change configuration to use 32 samples averaging for both bus voltage and shunt voltage
ina219_1.bus_adc_resolution = adafruit_ina219.ADCResolution.ADCRES_12BIT_32S
ina219_1.shunt_adc_resolution = adafruit_ina219.ADCResolution.ADCRES_12BIT_32S
# optional : change voltage range to 16V
ina219_1.bus_voltage_range = adafruit_ina219.BusVoltageRange.RANGE_16V

# measure and display loop
while True:
    bus_voltage_0 = ina219_0.bus_voltage  # voltage on V- (load side)
    shunt_voltage_0 = ina219_0.shunt_voltage  # voltage between V+ and V- across the shunt
    current_0 = ina219_0.current  # current in mA
    power_0 = ina219_0.power  # power in watts

    # INA219 measure bus voltage on the load side. So PSU voltage = bus_voltage + shunt_voltage
    print("CHANNEL 1")
    print("Voltage (VIN+) : {:6.3f}   V".format(bus_voltage_0 + shunt_voltage_0))
    print("Voltage (VIN-) : {:6.3f}   V".format(bus_voltage_0))
    print("Shunt Voltage  : {:8.5f} V".format(shunt_voltage_0))
    print("Shunt Current  : {:7.4f}  A".format(current_0 / 1000))
    print("Power Calc.    : {:8.5f} W".format(bus_voltage_0 * (current_0 / 1000)))
    print("Power Register : {:6.3f}   W".format(power_0))
    print("")

    # Check internal calculations haven't overflowed (doesn't detect ADC overflows)
    if ina219_0.overflow:
        print("Internal Math Overflow Detected!")
        print("")
    
    
    bus_voltage_1 = ina219_1.bus_voltage  # voltage on V- (load side)
    shunt_voltage_1 = ina219_1.shunt_voltage  # voltage between V+ and V- across the shunt
    current_1 = ina219_1.current  # current in mA
    power_1 = ina219_1.power  # power in watts

    # INA219 measure bus voltage on the load side. So PSU voltage = bus_voltage + shunt_voltage    
    print("CHANNEL 2")
    print("Voltage (VIN+) : {:6.3f}   V".format(bus_voltage_1 + shunt_voltage_1))
    print("Voltage (VIN-) : {:6.3f}   V".format(bus_voltage_1))
    print("Shunt Voltage  : {:8.5f} V".format(shunt_voltage_1))
    print("Shunt Current  : {:7.4f}  A".format(current_1 / 1000))
    print("Power Calc.    : {:8.5f} W".format(bus_voltage_1 * (current_1 / 1000)))
    print("Power Register : {:6.3f}   W".format(power_1))
    print("")

    # Check internal calculations haven't overflowed (doesn't detect ADC overflows)
    if ina219_1.overflow:
        print("Internal Math Overflow Detected!")
        print("")

    time.sleep(2)