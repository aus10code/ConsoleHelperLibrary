namespace ConsoleHelperLibrary;

using Models;

public static class RequestInput
{
    public static string RequestStringFromConsole(this string messageToUser)
    {
        Console.Write($"{messageToUser}");
        return Console.ReadLine();
    }

    public static RequestIntModel RequestIntFromConsole(this string messageToUser)
    {
        var intModel = new RequestIntModel();
        intModel.RequestMessage = messageToUser;
        intModel.ErrorMessages.Add($"the number ");

        return intModel;
    }
}


//
// public static int RequestInt(this string message, string errorMessage = "Please enter a valid number.")
// {
//     return message.RequestInt(errorMessage, Int32.MinValue, Int32.MaxValue);
// }
//
// public static int RequestInt(this string message, string errorMessage, int minValue, int maxValue)
// {
//     int output = 0;
//     bool isInteger;
//     bool isValidNumber;
//
//     do
//     {
//         isInteger = false;
//         Console.Write(message);
//         var intString = Console.ReadLine();
//
//         isInteger = int.TryParse(intString, out output);
//
//         isValidNumber = (!isInteger || (output < minValue || output > maxValue));
//
//         if (isValidNumber)
//         {
//             Console.WriteLine(errorMessage);
//         }
//     } while (isValidNumber);
//
//     return output;
// }
