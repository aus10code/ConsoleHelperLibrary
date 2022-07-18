namespace ConsoleHelperLibrary.Models;

public class RequestIntModel : RequestTypeModel
{
    internal Dictionary<Enums.IntCheck, bool> ErrorMessagesStatus { get; set; } =
        new Dictionary<Enums.IntCheck, bool>();

    public int UserInputValue { get; set; }
    private int MinValue { get; set; } = int.MinValue;
    private int MaxValue { get; set; } = int.MaxValue;


    public RequestIntModel WithMinValueOf(int minValue)
    {
        MinValue = minValue;

        ErrorMessages.Add($"{MinValue} or greater");
        ErrorMessagesStatus.Add(Enums.IntCheck.Min, false);

        return this;
    }

    public RequestIntModel WithMaxValueOf(int maxValue)
    {
        MaxValue = maxValue;

        ErrorMessages.Add($"{MaxValue} or less");
        ErrorMessagesStatus.Add(Enums.IntCheck.Max, false);

        return this;
    }

    public RequestIntModel WithOnlyPositives()
    {
        ErrorMessages.Add("positive");
        ErrorMessagesStatus.Add(Enums.IntCheck.Positive, false);

        return this;
    }

    public RequestIntModel WithOnlyNegatives()
    {
        ErrorMessages.Add("negative");
        ErrorMessagesStatus.Add(Enums.IntCheck.Negative, false);

        return this;
    }

    public int Close()
    {
        var errorsFound = false;

        do
        {
            //Check if it's a number
            var userInputString = RequestMessage.RequestStringFromConsole();
            bool isValidInt = int.TryParse(userInputString.UserInputValue, out int validInt);

            if (isValidInt)
            {
                this.UserInputValue = validInt;
                ErrorMessagesStatus[Enums.IntCheck.MustBeNumber] = false;
            }
            else
            {
                ErrorMessagesStatus[Enums.IntCheck.MustBeNumber] = true;
            }

            if (isValidInt && ErrorMessagesStatus.ContainsKey(Enums.IntCheck.Min))
            {
                if (this.UserInputValue >= MinValue)
                {
                    ErrorMessagesStatus[Enums.IntCheck.Min] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.IntCheck.Min] = true;
                }
            }

            if (isValidInt && ErrorMessagesStatus.ContainsKey(Enums.IntCheck.Max))
            {
                if (UserInputValue <= MaxValue)
                {
                    ErrorMessagesStatus[Enums.IntCheck.Max] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.IntCheck.Max] = true;
                }
            }

            if (isValidInt && ErrorMessagesStatus.ContainsKey(Enums.IntCheck.Positive))
            {
                if (UserInputValue >= 0)
                {
                    ErrorMessagesStatus[Enums.IntCheck.Positive] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.IntCheck.Positive] = true;
                }
            }

            if (isValidInt && ErrorMessagesStatus.ContainsKey(Enums.IntCheck.Negative))
            {
                if (UserInputValue < 0)
                {
                    ErrorMessagesStatus[Enums.IntCheck.Negative] = false;
                }
                else
                {
                    ErrorMessagesStatus[Enums.IntCheck.Negative] = true;
                }
            }

            errorsFound = ErrorMessagesStatus.Any(t => t.Value == true);

            PrintErrorsToConsole(errorsFound, ErrorMessages, ErrorMessagesStatus);
        } while (errorsFound);


        return this.UserInputValue;
    }


}
