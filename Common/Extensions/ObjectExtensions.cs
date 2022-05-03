namespace Bede.SlotMachine.Common.Extensions;

public static class ObjectExtensions
{
    public static void NotNullArgument(this object arg, string paramName)
    {
        if (arg == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}