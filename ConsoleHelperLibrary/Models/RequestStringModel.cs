namespace ConsoleHelperLibrary.Models;

public class RequestStringModel : RequestTypeModel
{
    public string UserInputValue { get; set; }

    internal Dictionary<Enums.StringCheck, bool> ErrorMessagesStatus { get; set; } = new Dictionary<Enums.StringCheck, bool>();
}
