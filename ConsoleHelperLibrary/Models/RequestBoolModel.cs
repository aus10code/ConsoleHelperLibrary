namespace ConsoleHelperLibrary.Models;

public class RequestBoolModel : RequestTypeModel
{
    public string UserInputValue { get; set; }

    internal Dictionary<Enums.BoolCheck, bool> ErrorMessagesStatus { get; set; } = new();
    internal List<string> TrueList { get; set; } = new();
    internal List<string> FalseList { get; set; } = new();

    public bool Close()
    {
        var output = false;



        return output;
    }
}
