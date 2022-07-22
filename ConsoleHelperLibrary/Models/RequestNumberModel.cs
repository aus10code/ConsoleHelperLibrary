namespace ConsoleHelperLibrary.Models;

using System.Globalization;
using System.Runtime.CompilerServices;

public class RequestNumberModel<T> : RequestTypeModel where T : IComparable
{
    internal Dictionary<Enums.NumberCheck, bool> ErrorMessagesStatus { get; set; } = new();

    public T UserInputValue { get; set; }

    internal T? MinValue { get; set; } //= (T)(object)int.MaxValue;
    internal T? MaxValue { get; set; } //= typeof(T).MaxValue<T>();


    public RequestNumberModel<T> WithMinValueOf(T minValue)
    {
        this.MinValue = minValue;

        this.ErrorMessages.Add($"{this.MinValue} or greater");
        this.ErrorMessagesStatus.Add(Enums.NumberCheck.Min, false);

        return this;
    }

    public RequestNumberModel<T> WithMaxValueOf(T maxValue)
    {
        this.MaxValue = maxValue;

        this.ErrorMessages.Add($"{this.MaxValue} or less");
        this.ErrorMessagesStatus.Add(Enums.NumberCheck.Max, false);

        return this;
    }

    public RequestNumberModel<T> WithOnlyPositives()
    {
        this.ErrorMessages.Add("positive");
        this.ErrorMessagesStatus.Add(Enums.NumberCheck.Positive, false);

        return this;
    }

    public RequestNumberModel<T> WithOnlyNegatives()
    {
        this.ErrorMessages.Add("negative");
        this.ErrorMessagesStatus.Add(Enums.NumberCheck.Negative, false);

        return this;
    }


    public T Close()
    {
        var errorsFound = false;

        // Continues until no errors are found
        do
        {
            var userInputString = this.RequestMessage.GetUserInput();
            (bool isNumber, T number) = this.SetIsNumber<T>(userInputString);

            if (isNumber)
            {
                this.UserInputValue = number;
                this.ErrorMessagesStatus[Enums.NumberCheck.MustBeNumber] = false;
            }
            else
            {
                this.ErrorMessagesStatus[Enums.NumberCheck.MustBeNumber] = true;
            }

            SetErrorMessagesIfNumber<T>(isNumber, number);

            errorsFound = this.ErrorMessagesStatus.Any(t => t.Value);

            PrintErrorsToConsole(errorsFound, this.ErrorMessages, this.ErrorMessagesStatus);
        } while (errorsFound);


        return this.UserInputValue;
    }



    public void SetErrorMessagesIfNumber<T>(bool isNumber, T number)
    {
        // allows for comparison for positives/negatives of different types.
        var ZeroOfTypeT = 0.ConvertTo<T>();

        if (isNumber && this.ErrorMessagesStatus.ContainsKey(Enums.NumberCheck.Min))
        {
            this.ErrorMessagesStatus[Enums.NumberCheck.Min] = (this.UserInputValue.CompareTo(this.MinValue) < 0);
        }

        if (isNumber && this.ErrorMessagesStatus.ContainsKey(Enums.NumberCheck.Max))
        {
            this.ErrorMessagesStatus[Enums.NumberCheck.Max] = (this.UserInputValue.CompareTo(this.MaxValue) >= 0);
        }

        if (isNumber && this.ErrorMessagesStatus.ContainsKey(Enums.NumberCheck.Positive))
        {
            this.ErrorMessagesStatus[Enums.NumberCheck.Positive] =
                (this.UserInputValue.CompareTo(ZeroOfTypeT) <= 0);
        }

        if (isNumber && this.ErrorMessagesStatus.ContainsKey(Enums.NumberCheck.Negative))
        {
            this.ErrorMessagesStatus[Enums.NumberCheck.Negative] = (this.UserInputValue.CompareTo(ZeroOfTypeT) > 0);
        }
    }

    public (bool isNumber, T number) SetIsNumber<T>(string userInputString)
    {
        bool isNumber;
        T number = default(T);

        try
        {
            number = userInputString.ConvertTo<T>();
            isNumber = true;
        }
        catch
        {
            isNumber = false;
        }

        // if (typeof(T) == typeof(int))
        // {
        //     isNumber = int.TryParse(userInputString, out var num);
        //     var a = (T)Convert.ChangeType(userInputString, typeof(T), CultureInfo.InvariantCulture);
        //     number = num.ConvertTo<T>();
        // }
        // else if (typeof(T) == typeof(double))
        // {
        //     isNumber = double.TryParse(userInputString, out var num);
        //     number = num.ConvertTo<T>();
        // }
        // else if (typeof(T) == typeof(decimal))
        // {
        //     isNumber = decimal.TryParse(userInputString, out var num);
        //     number = num.ConvertTo<T>();
        // }
        // else
        // {
        //     isNumber = false;
        // }

        return (isNumber, number);
    }
}
