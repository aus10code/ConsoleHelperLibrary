# ConsoleLibraryHelper
<p align="center">
[![](https://img.shields.io/nuget/v/austen.ConsoleHelperLibrary)](https://www.nuget.org/packages/austen.ConsoleHelperLibrary/)[![](https://img.shields.io/nuget/dt/austen.ConsoleHelperLibrary)](https://www.nuget.org/packages/austen.ConsoleHelperLibrary/)[![GitHub](https://badgen.net/badge/icon/github?icon=github&label)](https://github.com/aus10code/ConsoleHelperLibrary)[![](https://img.shields.io/github/license/aus10code/ConsoleHelperLibrary)](https://img.shields.io/github/license/aus10code/ConsoleHelperLibrary)
</p>
ConsoleLibraryHelper simplifies the capture of string, boolean, and number types from console users.

To use this library, add the "using ConsoleHelperLibrary" statement

## Explanation
### String
```csharp
"What is your first name: ".RequestStringFromConsole().WithNoSpaces().Close();
```
RequestStringFromConsole
- WithMinLengthOf(int minLength)
- WithMaxLengthOf(int maxLength)
- WithNoSpaces()
- WithNoSpecialCharacters()
- WithNoNumbers()


### Number
```csharp
"What is your age: ".RequestNumberFromConsole<int>.Close();
"How much money do you have: ".RequestNumberFromConsole<decimal>.WithOnlyPositives().Close();
```
RequestNumberFromConsole`<T>`
- WithMinValueOf(T minimumValue)
- WIthMaxValueOf(T maximumValue)
- WithOnlyPositives()
- WithOnlyNegatives()

*Type T can be any of the following number types*
- System.Boolean
- System.Byte
- System.Char
- System.Decimal
- System.Double
- System.SByte
- System.Single
- System.UInt16
- System.UInt32
- System.UInt64

### Bool
```csharp
"Are you over 18: ".RequestBoolFromConsole().Close();
```

**The following rules are always true**
1. All methods extend objects of type string. 
2. All requirement methods begin with the keyword **With**
	1. i.e WithNoSpaces(), WithNoNumbers() etc..
3. All request methods must end with a .Close()
	
Furthermore, you can put requirements on each of the request methods that help control the data the app receives. They can be used individually or chained together in any order you may like. Check How To Use section

## How To Use
### Request Number From Console That Is
- An integer
- A positive number
- Greater than 5
- Less than 50

![](https://raw.githubusercontent.com/aus10code/ConsoleHelperLibrary/main/images/large/RequestNumberFromConsole.gif)

### Request String From Console That Contains
- No numbers
- No special characters
- No white spaces

![](https://raw.githubusercontent.com/aus10code/ConsoleHelperLibrary/main/images/large/RequestStringFromConsole.gif)

### Request Boolean From Console

![](https://raw.githubusercontent.com/aus10code/ConsoleHelperLibrary/main/images/large/RequestBoolFromConsole.gif)