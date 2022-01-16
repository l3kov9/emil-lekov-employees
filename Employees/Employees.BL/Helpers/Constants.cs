namespace Employees.BL.Helpers
{
    public static class Constants
    {
        public static string InvalidParameters(string line) => $"Invalid parameters: {line}";

        public static string InvalidArgument(string type, string value) => $"Invalid {type} argument: {value}.";
    }
}
