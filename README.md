# Roomex
## Distance between two points

This repository contains an example Web API application that can work out the difference between two coordinates.
It is hosted within Azure\ and is deployed using GitHub actions, using terraform to manage the infrastructure.

To calculate the distance, send a POST request to /Distance/Calculate with the following payload

```
{
	"CoordinateA": {
    "Latitude": 53.297975,
		"Longitude": -6.372663
	},
	"CoordinateB": {
		"Latitude": 41.385101,
		"Longitude": -81.440440
	}
}
```
If you would like to test this in Azure, the service is hosted at
https://roomex-api.azurewebsites.net/Distance/Calculate

You can also optionally change the calculation method, and the output units by providing `CalculationMethod` or `UnitOutput`.

The values of which can be found below.

### Calculation Method

| Calculation Method          | Value |
| --------------------------- | ----- |
| Polar Coordinate Flat Earth | 0     |
| Spherical Law of Cosine     | 1     |
| Vincenty Inverse            | 2     |

### Calculation Method

| Unit Output | Value |
| ----------- | ----- |
| Kilometres  | 0     |
| Miles       | 1     |
| Parsecs     | 2     |

For example, the below payload can be used to calculate the distance between two points using the Vincenty Inverse formula, outputting the result in Miles.

```
{
	"CoordinateA": {
		"Latitude": 53.297975,
		"Longitude": -6.372663
	},
	"CoordinateB": {
		"Latitude": 41.385101,
		"Longitude": -81.440440
	},
	"CalculationMethod": 2,
	"UnitOutput": 1
}
```
