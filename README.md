<h1 align="center">
    ConsoleLibraryHelper
</h1>

<p align="center">
	<a href="https://www.nuget.org/packages/austen.ConsoleHelperLibrary/" alt="">
	        <img src="https://img.shields.io/nuget/v/austen.ConsoleHelperLibrary" /></a>
	<a href="https://www.nuget.org/packages/austen.ConsoleHelperLibrary/" alt="">
	        <img src="https://img.shields.io/nuget/dt/austen.ConsoleHelperLibrary" /></a>
	<a href="https://badgen.net/badge/icon/github?icon=github&label" alt="">
	        <img src="https://badgen.net/badge/icon/github?icon=github&label" /></a>
	<a href="https://img.shields.io/github/license/aus10code/ConsoleHelperLibrary" alt="">
	        <img src="https://img.shields.io/github/license/aus10code/ConsoleHelperLibrary" /></a>
</p>

ConsoleLibraryHelper simplifies the capture of string, boolean, and number types from console users.

To use this library, add the "using ConsoleHelperLibrary" statement

## Explanation
You can request either a string, boolean, or number type. 

Each of the 3 types have unique requirements you can place on the data you will be requesting.  If data returned by user is invalid, it will state the error and prompt the user to try again.

Some requirement examples include a minimum or maximum string length or only allowing positive numbers. They can be used individually or chained together in any order you may like

### String
```csharp
"What is your first name: ".RequestStringFromConsole().WithNoSpaces().Close();
```
RequestStringFromConsole
- `WithMinLengthOf(int minLength)`
- `WithMaxLengthOf(int maxLength)`
- `WithNoSpaces()`
- `WithNoSpecialCharacters()`
- `WithNoNumbers()`
- `WithOnlyTheseOptions(List<string> options)`


### Number
```csharp
"What is your age: ".RequestNumberFromConsole<int>.Close();
"How much money do you have: ".RequestNumberFromConsole<decimal>.WithOnlyPositives().Close();
```
RequestNumberFromConsole`<T>`
- `WithMinValueOf(T minimumValue)`
- `WIthMaxValueOf(T maximumValue)`
- `WithOnlyPositives()`
- `WithOnlyNegatives()`

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
	1. i.e `WithNoSpaces()`, `WithNoNumbers()` etc..
3. All request methods must end with a `.Close()`

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