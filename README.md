# ConsoleLibraryHelper

ConsoleLibraryHelper was designed to simplify data requests from users in console applications

To use this library, add a using ConsoleHelperLibrary

Available Extension Methods:

RequestBoolFromConsole
RequestStringFromConsole
RequestNumberFromConsole

## How To Use

All methods extend the string class. In order to request data using ConsoleHelperLibrary you must extend a string like below
```
"What is your age".RequestNumberFromConsole<int>.Close();
```
## Examples
Request number from console that is
- An integer
- A positive number
- Greater than 5
- Less than 50

![](https://raw.githubusercontent.com/aus10code/ConsoleHelperLibrary/main/images/large/RequestNumberFromConsole.gif)

Request string from console that contains
- No numbers
- No special characters
- No white spaces

![](https://raw.githubusercontent.com/aus10code/ConsoleHelperLibrary/main/images/large/RequestStringFromConsole.gif)

Request bool from console

![](https://raw.githubusercontent.com/aus10code/ConsoleHelperLibrary/main/images/large/RequestBoolFromConsole.gif)