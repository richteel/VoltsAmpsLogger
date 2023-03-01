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
print(f"  bus_voltage_range:    {ina219_0.bus_voltage_range}")
print(f"  gain:                 {ina219_0.gain}")
print(f"  bus_adc_resolution:   {ina219_0.bus_adc_resolution}")
print(f"  shunt_adc_resolution: {ina219_0.shunt_adc_resolution}")
print(f"  mode:                 {ina219_0.mode}")
print("")

# display some of the advanced field (just to test)
print("Config register Channel 2:")
print(f"  bus_voltage_range:    {ina219_1.bus_voltage_range}")
print(f"  gain:                 {ina219_1.gain}")
print(f"  bus_adc_resolution:   {ina219_1.bus_adc_resolution}")
print(f"  shunt_adc_resolution: {ina219_1.shunt_adc_resolution}")
print(f"  mode:                 {ina219_1.mode}")
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
    # voltage between V+ and V- across the shunt
    shunt_voltage_0 = ina219_0.shunt_voltage
    current_0 = ina219_0.current  # current in mA
    power_0 = ina219_0.power  # power in watts

    # INA219 measure bus voltage on the load side. So PSU voltage = bus_voltage + shunt_voltage
    print("CHANNEL 1")
    print(f"Voltage (VIN+) : {(bus_voltage_0 + shunt_voltage_0):6.3f}   V")
    print(f"Voltage (VIN-) : {bus_voltage_0:6.3f}   V")
    print(f"Shunt Voltage  : {shunt_voltage_0:8.5f} V")
    print(f"Shunt Current  : {(current_0 / 1000):7.4f}  A")
    print(f"Power Calc.    : {(bus_voltage_0 * (current_0 / 1000)):8.5f} W")
    print(f"Power Register : {power_0:6.3f}   W")
    print("")

    # Check internal calculations haven't overflowed (doesn't detect ADC overflows)
    if ina219_0.overflow:
        print("Internal Math Overflow Detected!")
        print("")

    bus_voltage_1 = ina219_1.bus_voltage  # voltage on V- (load side)
    # voltage between V+ and V- across the shunt
    shunt_voltage_1 = ina219_1.shunt_voltage
    current_1 = ina219_1.current  # current in mA
    power_1 = ina219_1.power  # power in watts

    # INA219 measure bus voltage on the load side. So PSU voltage = bus_voltage + shunt_voltage
    print("CHANNEL 2")
    print(f"Voltage (VIN+) : {(bus_voltage_1 + shunt_voltage_1):6.3f}   V")
    print(f"Voltage (VIN-) : {bus_voltage_1:6.3f}   V")
    print(f"Shunt Voltage  : {shunt_voltage_1:8.5f} V")
    print(f"Shunt Current  : {(current_1 / 1000):7.4f}  A")
    print(f"Power Calc.    : {(bus_voltage_1 * (current_1 / 1000)):8.5f} W")
    print(f"Power Register : {power_1:6.3f}   W")
    print("")

    # Check internal calculations haven't overflowed (doesn't detect ADC overflows)
    if ina219_1.overflow:
        print("Internal Math Overflow Detected!")
        print("")

    time.sleep(2)
