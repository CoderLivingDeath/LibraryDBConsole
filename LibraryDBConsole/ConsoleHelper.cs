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

        public static void ShowTable(string[] headers, string[][] tables)
        {
            // Check if the number of columns in each row matches the number of headers
            if (tables.Any(row => row.Length != headers.Length))
            {
                throw new ArgumentException("The number of columns in each row must match the number of headers.");
            }

            int[] columnWidths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                columnWidths[i] = headers[i].Length;
                foreach (var row in tables)
                {
                    columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
                }
            }

            PrintRow(headers, columnWidths, true);

            PrintSeparator(columnWidths);

            foreach (var row in tables)
            {
                PrintRow(row, columnWidths, false);
            }
        }

        private static void PrintRow(string[] row, int[] columnWidths, bool isHeader)
        {
            for (int i = 0; i < row.Length; i++)
            {
                string cell = row[i];
                Console.Write(cell.PadRight(columnWidths[i] + 2));
            }
            Console.WriteLine();
        }

        private static void PrintSeparator(int[] columnWidths)
        {
            for (int i = 0; i < columnWidths.Length; i++)
            {
                Console.Write(new string('-', columnWidths[i] + 2));
            }
            Console.WriteLine();
        }
    }
}
