namespace ConsoleHelperLibrary;

using Models;

public static class RequestInput
{
    public static string GetUserInput(this string messageToUser)
    {
        Console.Write(messageToUser);
        return Console.ReadLine();
    }
    public static RequestStringModel RequestStringFromConsole(this string messageToUser)
    {
        var stringModel = new RequestStringModel();
        stringModel.RequestMessage = messageToUser;

        return stringModel;
    }

    public static RequestIntModel RequestIntFromConsole(this string messageToUser)
    {
        var intModel = new RequestIntModel();
        intModel.RequestMessage = messageToUser;

        intModel.ErrorMessages.Add($"Must be a number");
        intModel.ErrorMessagesStatus.Add(Enums.IntCheck.MustBeNumber, false);

        return intModel;
    }
}



