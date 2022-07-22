namespace ConsoleHelperLibrary;

using System.ComponentModel;
using System.Globalization;

public static class Conversions
{
    public static T ConvertTo<T>(this object value)
    {
        T output;

        // if same type
        if (value is T type)
        {
            output = type;
        }
        else
        {
            try
            {
                if (Nullable.GetUnderlyingType(typeof(T)) != null)
                {
                    output = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value)!;
                }
                else
                {
                    output = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
                }
            }
            catch (Exception)
            {
                output = default(T)!;
            }
        }

        return output;
    }
}
