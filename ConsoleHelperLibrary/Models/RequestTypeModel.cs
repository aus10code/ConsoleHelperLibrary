namespace ConsoleHelperLibrary.Models;

public class RequestTypeModel
{
    internal string RequestMessage { get; set; }
    internal List<string> ErrorMessages { get; set; } = new List<string>();
    public static void PrintErrorsToConsole<T>(bool errorsFound, List<string> errorMessages,
        Dictionary<T, bool> errorMessagesStatus) where T : System.Enum
    {
        if (errorsFound)
        {
            for (int i = 0; i < errorMessages.Count; i++)
            {
                if (i == 0)
                {
                    ConsoleExt.WriteToConsole($"{errorMessages[i]}", errorMessagesStatus.ElementAt(i).Value);
                }
                else if (i == 1)
                {
                    Console.Write(" that is ");
                    ConsoleExt.WriteToConsole($"{errorMessages[i]}", errorMessagesStatus.ElementAt(i).Value);
                }
                else if (i < errorMessages.Count - 1)
                {
                    Console.Write(", ");
                    ConsoleExt.WriteToConsole($"{errorMessages[i]}", errorMessagesStatus.ElementAt(i).Value);
                }
                else
                {
                    Console.Write(" and ");
                    ConsoleExt.WriteToConsole($"{errorMessages[i]}", errorMessagesStatus.ElementAt(i).Value);
                }
            }

            Console.WriteLine();
        }
    }
}
