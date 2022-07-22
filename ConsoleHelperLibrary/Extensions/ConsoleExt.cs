namespace ConsoleHelperLibrary;

using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Models;

public static class ConsoleExt
{
    //Console Extension Class
    public static void WriteToConsole(string errorMessage, bool invertColor)
    {
        if (invertColor)
        {
            WriteInvertColor(errorMessage);
        }
        else
        {
            Console.Write(errorMessage);
        }

        static void WriteInvertColor(string message)
        {
            (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);
            Console.Write(message);
            (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);
        }
    }

    public static string GetUserInput(this string messageToUser)
    {
        Console.Write(messageToUser);
        return Console.ReadLine();
    }
}
