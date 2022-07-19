namespace ConsoleHelperLibrary.Models;

public class RequestStringModel : RequestTypeModel
{
    public string UserInputValue { get; set; }

    public int MinLength { get; set; }
    public int MaxLength { get; set; }

    internal Dictionary<Enums.StringCheck, bool> ErrorMessagesStatus { get; set; } =
        new Dictionary<Enums.StringCheck, bool>();

    public RequestStringModel WithMinLengthOf(int minStringLength)
    {
        MinLength = minStringLength;

        ErrorMessages.Add($"{MinLength} characters long or more");
        ErrorMessagesStatus.Add(Enums.StringCheck.MinLength, false);

        return this;
    }

    public RequestStringModel WithMaxLengthOf(int maxStringLength)
    {
        MaxLength = maxStringLength;

        ErrorMessages.Add($"{MaxLength} characters long or less");
        ErrorMessagesStatus.Add(Enums.StringCheck.MinLength, false);

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

    public string Close()
    {
        var errorsFound = false;

        do
        {
            //Check if it's a number
            UserInputValue = RequestMessage.GetUserInput();

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.MinLength))
            {
                if (UserInputValue.Length >= MinLength)
                {
                    ErrorMessagesStatus[Enums.StringCheck.MinLength] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.StringCheck.MaxLength] = true;
                }
            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.MaxLength))
            {
                if (UserInputValue.Length <= MaxLength)
                {
                    ErrorMessagesStatus[Enums.StringCheck.MaxLength] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.StringCheck.MaxLength] = true;
                }
            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.NoSpaces))
            {
                // Must contain no spaces

                if (true)
                {
                    ErrorMessagesStatus[Enums.StringCheck.NoSpaces] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.StringCheck.NoSpaces] = true;
                }
            }

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.NoSpecialCharacters))
            {
                if (true)
                {
                    ErrorMessagesStatus[Enums.StringCheck.NoSpecialCharacters] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.StringCheck.NoSpecialCharacters] = true;
                }
            }

            errorsFound = ErrorMessagesStatus.Any(t => t.Value == true);

            PrintErrorsToConsole(errorsFound, ErrorMessages, ErrorMessagesStatus);
        } while (errorsFound);


        return UserInputValue;
    }
}
