namespace ConsoleHelperLibrary;

public static class ConsoleEx
{
    //Console Extension Class
    public static void WriteInvertColor(string message)
    {
        (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);
        Console.Write(message);
        (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);
    }
}
