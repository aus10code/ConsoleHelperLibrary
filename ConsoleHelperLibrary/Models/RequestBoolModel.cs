namespace ConsoleHelperLibrary.Models;

public class RequestBoolModel : RequestTypeModel
{
    public bool UserInputValue { get; set; }

    internal Dictionary<Enums.BoolCheck, bool> ErrorMessagesStatus { get; set; } = new();

    internal List<string> TrueList { get; set; } = new() { "yes", "yay", "sure", "yea", "yeah", "yup", "okay", "ok", "aye", "yah", "true", "positive" };
    internal List<string> FalseList { get; set; } = new() { "no", "never", "nein", "negative", "nix", "no thanks", "nope", "false", "nay" };

public bool Close()
    {
        var errorsFound = false;

        // Continues until no errors are found
        do
        {
            bool isBool;
            var userInputString = this.RequestMessage.GetUserInput();

            if (ErrorMessagesStatus.ContainsKey(Enums.BoolCheck.IsBool))
            {
                if (TrueList.Contains(userInputString))
                {
                    this.UserInputValue = true;
                    ErrorMessagesStatus[Enums.BoolCheck.IsBool] = false;
                }
                else if (FalseList.Contains(userInputString))
                {
                    this.UserInputValue = false;
                    ErrorMessagesStatus[Enums.BoolCheck.IsBool] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.BoolCheck.IsBool] = true;
                }

                isBool = ErrorMessagesStatus[Enums.BoolCheck.IsBool];
            }

            errorsFound = this.ErrorMessagesStatus.Any(t => t.Value);

            PrintErrorsToConsole(errorsFound, this.ErrorMessages, this.ErrorMessagesStatus);
        } while (errorsFound);


        return this.UserInputValue;
    }
}
