namespace ConsoleHelperLibrary.Models;

public class Enums
{
    public enum NumberCheck
    {
        MustBeNumber, Min, Max, Positive, Negative
    }
    public enum IntCheck
    {
        MustBeNumber, Min, Max, Positive, Negative
    }

    public enum StringCheck
    {
        MinLength, MaxLength, NoSpaces, NoSpecialCharacters
    }

    public enum DoulbeCheck
    {
        MustBeNumber, Min, Max, Positive, Negative
    }

    public enum DecimalCheck
    {
        MustBeNumber, Min, Max, Positive, Negative
    }

    public enum BoolCheck
    {
        //???
    }
}
