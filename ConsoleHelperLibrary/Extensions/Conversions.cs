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
            if (Nullable.GetUnderlyingType(typeof(T)) != null)
            {
                output = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value)!;
            }
            else
            {
                // likely to throw error. Knowingly letting exception bubble up
                output = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }
        }

        return output;
    }
}
