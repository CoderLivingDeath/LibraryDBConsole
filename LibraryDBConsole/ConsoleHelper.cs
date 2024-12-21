namespace LibraryDBConsole
{
    public static class ConsoleHelper
    {
        public static string? ListenString()
        {
            return Console.ReadLine();
        }

        public static int? ListenInt()
        {
            string message = Console.ReadLine();
            if (int.TryParse(message, out int result))
            {
                return result;
            }

            throw new Exception("Error int parse: " + message);
        }

        public static double? ListenDouble()
        {
            string message = Console.ReadLine();
            if (double.TryParse(message, out double result))
            {
                return result;
            }

            throw new Exception("Error int parse: " + message);
        }
    }
}
