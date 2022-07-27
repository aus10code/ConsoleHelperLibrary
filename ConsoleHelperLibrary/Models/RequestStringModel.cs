namespace ConsoleHelperLibrary.Models;

using System.Text.RegularExpressions;

public class RequestStringModel : RequestTypeModel
{
    public string UserInputValue { get; set; }

    public int MinLength { get; set; }
    public int MaxLength { get; set; }

    internal Dictionary<Enums.StringCheck, bool> ErrorMessagesStatus { get; set; } = new();

    public RequestStringModel WithMinLengthOf(int minStringLength)
    {
        MinLength = minStringLength;

        ErrorMessages.Add($"{MinLength} characters or more");
        ErrorMessagesStatus.Add(Enums.StringCheck.MinLength, false);

        return this;
    }

    public RequestStringModel WithMaxLengthOf(int maxStringLength)
    {
        MaxLength = maxStringLength;

        ErrorMessages.Add($"{MaxLength} characters or less");
        ErrorMessagesStatus.Add(Enums.StringCheck.MaxLength, false);

        return this;
    }

    public RequestStringModel WithNoSpaces()
    {
        ErrorMessages.Add("no white spaces");
        ErrorMessagesStatus.Add(Enums.StringCheck.NoSpaces, false);

        return this;
    }

    public RequestStringModel WithNoSpecialCharacters()
    {
        ErrorMessages.Add("no special characters");
        ErrorMessagesStatus.Add(Enums.StringCheck.NoSpecialCharacters, false);

        return this;
    }

    public RequestStringModel WithNoNumbers()
    {
        ErrorMessages.Add("no numbers");
        ErrorMessagesStatus.Add(Enums.StringCheck.NoNumbers, false);

        return this;
    }

    public string Close()
    {
        var errorsFound = false;

        do
        {
            //Check if it's a number
            UserInputValue = RequestMessage.GetUserInput().Trim();

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.MinLength))
            {
                ErrorMessagesStatus[Enums.StringCheck.MinLength] = (UserInputValue.Length < MinLength);

            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.MaxLength))
            {
                ErrorMessagesStatus[Enums.StringCheck.MaxLength] = (UserInputValue.Length > MaxLength);
            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.NoSpaces))
            {
                var regex = new Regex(@"\s");

                ErrorMessagesStatus[Enums.StringCheck.NoSpaces] = (regex.IsMatch(UserInputValue));
            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.NoSpecialCharacters))
            {
                var regex = new Regex(@"[^ A-Za-z\d]");

                ErrorMessagesStatus[Enums.StringCheck.NoSpecialCharacters] = (regex.IsMatch(UserInputValue));
            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.NoNumbers))
            {
                var regex = new Regex(@"\d");

                ErrorMessagesStatus[Enums.StringCheck.NoNumbers] = (regex.IsMatch(UserInputValue));
            }

            errorsFound = ErrorMessagesStatus.Any(t => t.Value == true);

            PrintErrorsToConsole(errorsFound, ErrorMessages, ErrorMessagesStatus);
        } while (errorsFound);


        return UserInputValue;
    }
}
