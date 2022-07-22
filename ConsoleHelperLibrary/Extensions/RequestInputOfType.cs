namespace ConsoleHelperLibrary;

using Models;

public static class RequestInput
{
    public static RequestStringModel RequestStringFromConsole(this string messageToUser)
    {
        var stringModel = new RequestStringModel();
        stringModel.RequestMessage = messageToUser;

        return stringModel;
    }

    public static RequestNumberModel<int> RequestIntFromConsole(this string messageToUser)
    {
        var intModel = new RequestNumberModel<int>();

        intModel.AddMessagesForNumberType(messageToUser, "Must be a whole number");

        return intModel;
    }

    public static RequestNumberModel<double> RequestDoubleFromConsole(this string messageToUser)
    {
        var doubleModel = new RequestNumberModel<double>();

        doubleModel.AddMessagesForNumberType(messageToUser, "Must be a number");

        return doubleModel;
    }

    public static RequestNumberModel<decimal> RequestDecimalFromConsole(this string messageToUser)
    {
        var decimalModel = new RequestNumberModel<decimal>();

        decimalModel.AddMessagesForNumberType(messageToUser, "Must be a number");

        return decimalModel;
    }

    public static void AddMessagesForNumberType<T>(this RequestNumberModel<T> model, string messageToUser, string errorMessage) where T : IComparable
    {
        model.RequestMessage = messageToUser;

        model.ErrorMessages.Add(errorMessage);
        model.ErrorMessagesStatus.Add(Enums.NumberCheck.MustBeNumber, false);
    }
}



