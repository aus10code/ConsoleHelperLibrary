namespace ConsoleHelperLibrary.Models;

public class Enums
{
    public enum NumberCheck
    {
        MustBeNumber, Min, Max, Positive, Negative
    }
    public enum StringCheck
    {
        Text, MinLength, MaxLength, NoSpaces, NoSpecialCharacters, NoNumbers
    }

    public enum BoolCheck
    {
        IsBool
    }
}
