namespace ConsoleHelperLibrary.Models;

public class RequestIntModel
{
    internal HashSet<string> ErrorMessages { get; set; } = new HashSet<string>();

    internal string RequestMessage { get; set; }

    public int Value { get; set; }
    private int MinValue { get; set; } = int.MinValue;
    private int MaxValue { get; set; } = int.MaxValue;

    internal bool CheckMinValue { get; set; }
    internal bool CheckMaxValue { get; set; }
    internal bool CheckOnlyPositive { get; set; }
    internal bool CheckOnlyNegative { get; set; }


    public RequestIntModel WithMinValueOf(int minValue)
    {
        this.MinValue = minValue;
        this.CheckMinValue = true;

        this.ErrorMessages.Add($"must be {MinValue} or greater");

        return this;
    }

    public RequestIntModel WithMaxValueOf(int maxValue)
    {
        this.MaxValue = maxValue;
        this.CheckMaxValue = true;

        this.ErrorMessages.Add($"Number must be {MaxValue} or less");

        return this;
    }

    public RequestIntModel WithOnlyPositives()
    {
        this.CheckOnlyPositive = true;

        this.ErrorMessages.Add("Only positive numbers allowed");

        return this;
    }

    public RequestIntModel WithOnlyNegatives()
    {
        this.CheckOnlyNegative = true;

        this.ErrorMessages.Add("Only negative numbers allowed");

        return this;
    }

    public int Close()
    {
        do
        {
            //Check if it's a number
            var userInput = RequestMessage.RequestStringFromConsole();
            var errorCount = 0;

            bool isValidInt = int.TryParse(userInput, out var validInt);

            var errorMessage = $"Value entered must be a number";



            if (isValidInt)
            {
                Value = validInt;
                ErrorMessages.RemoveWhere(t => t.Equals(errorMessage, StringComparison.Ordinal));

                // maybe show which rule it failed, and which it passed
                // https://stackoverflow.com/questions/22131975/how-to-highlight-and-select-console-text-in-c-sharp-console
            }
            else
            {
                ErrorMessages.Add(errorMessage);
            }


            //WithMinValueOf
            if (isValidInt && CheckMinValue)
            {
                errorMessage = $"Number must be {MinValue} or greater";

                if (Value >= MinValue)
                {
                    ErrorMessages.RemoveWhere(t => t.Equals(errorMessage, StringComparison.Ordinal));
                }
                else
                {
                    ErrorMessages.Add(errorMessage);
                }
            }

            //WithMaxValueOf
            if (isValidInt && CheckMaxValue)
            {
                errorMessage = $"Number must be {MaxValue} or less";

                if (Value <= MaxValue)
                {
                    ErrorMessages.RemoveWhere(t => t.Equals(errorMessage, StringComparison.Ordinal));
                }
                else
                {
                    ErrorMessages.Add(errorMessage);
                }
            }

            //WithOnlyPositives
            if (isValidInt && CheckOnlyPositive)
            {
                errorMessage = $"Only positive numbers allowed";

                if (Value >= 0)
                {
                    ErrorMessages.RemoveWhere(t => t.Equals(errorMessage, StringComparison.Ordinal));
                }
                else
                {
                    ErrorMessages.Add(errorMessage);
                }
            }

            //WithOnlyNegatives
            if (isValidInt && CheckOnlyNegative)
            {
                errorMessage = $"Only negative numbers allowed";

                if (Value < 0)
                {
                    ErrorMessages.RemoveWhere(t => t.Equals(errorMessage, StringComparison.Ordinal));
                }
                else
                {
                    ErrorMessages.Add(errorMessage);
                }
            }

            if (ErrorMessages.Count > 0)
            {
                foreach (var message in ErrorMessages)
                {
                    Console.WriteLine(message);
                }
            }
        } while (ErrorMessages.Count > 0);


        return this.Value;
    }
}
