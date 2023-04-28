namespace ConsoleHelperLibrary.Models;

using System.Text.RegularExpressions;

public class RequestStringModel : RequestTypeModel
{
    public string UserInputValue { get; set; }
    public int MinLength { get; set; }
    public int MaxLength { get; set; }
    public List<string> Options { get; set; } = new();

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

    public RequestStringModel WithOnlyTheseOptions(List<string> options)
    {
        Options = options;

        string errorMessage = options.Count > 1 ? "one of these options: " : "this option: ";

        for (int i = 0; i < options.Count; i++)
        {
            if (options.Count == 2)
            {
                errorMessage += $"{options[0]} or {options[1]}, ";
                break;
            }

            if (i == options.Count - 1 && options.Count >= 3)
            {
                errorMessage = errorMessage.Remove(errorMessage.Length - 2);
                errorMessage += $" or {options[i]}, ";
                break;
            }

            errorMessage += $"{options[i]}, ";
        }

        errorMessage = errorMessage.Remove(errorMessage.Length - 2);

        ErrorMessages.Add(errorMessage);
        ErrorMessagesStatus.Add(Enums.StringCheck.OnlyTheseOptions, false);

        return this;
    }

    public string Close()
    {
        var errorsFound = false;

        do
        {
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

            if (ErrorMessagesStatus.ContainsKey(Enums.StringCheck.OnlyTheseOptions))
            {
                var missingOption = !Options.Contains(UserInputValue, StringComparer.InvariantCultureIgnoreCase);

                ErrorMessagesStatus[Enums.StringCheck.OnlyTheseOptions] = missingOption;
            }

            errorsFound = ErrorMessagesStatus.Any(t => t.Value == true);

            PrintErrorsToConsole(errorsFound, ErrorMessages, ErrorMessagesStatus);
        } while (errorsFound);


        return UserInputValue;
    }
}
