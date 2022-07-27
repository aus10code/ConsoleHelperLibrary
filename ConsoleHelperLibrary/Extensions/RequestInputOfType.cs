namespace ConsoleHelperLibrary;

using System.Runtime.CompilerServices;
using Models;

public static class RequestInput
{
    public static RequestStringModel RequestStringFromConsole(this string messageToUser)
    {
        var stringModel = new RequestStringModel();

        stringModel.RequestMessage = messageToUser;
        stringModel.ErrorMessages.Add($"Must be text");
        stringModel.ErrorMessagesStatus.Add(Enums.StringCheck.Text, false);

        return stringModel;
    }

    public static RequestNumberModel<T> RequestNumberFromConsole<T>(this string messageToUser) where T : IConvertible, IComparable
    {
        var numberModel = new RequestNumberModel<T>();
        var errorMessage = "Must be a number";

        CheckForUnsupportedTypes<T>();

        numberModel.AddMessagesForNumberType(messageToUser, errorMessage);

        return numberModel;
    }

    public static RequestBoolModel RequestBoolFromConsole(this string messageToUser)
    {
        var boolModel = new RequestBoolModel();

        return boolModel;
    }

    private static void CheckForUnsupportedTypes<T>()
    {
        if (typeof(T) == typeof(string) || typeof(T) == typeof(DateTime) || typeof(T) == typeof(DBNull) || typeof(T) == typeof(bool))
        {
            throw new TypeAccessException("Please use a number type with RequestNumberFromConsole<T>");
        }
    }

    public static void AddMessagesForNumberType<T>(this RequestNumberModel<T> model, string messageToUser, string errorMessage) where T : IConvertible, IComparable
    {
        model.RequestMessage = messageToUser;

        model.ErrorMessages.Add(errorMessage);
        model.ErrorMessagesStatus.Add(Enums.NumberCheck.MustBeNumber, false);
    }
}



