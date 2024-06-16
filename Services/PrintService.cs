using Microsoft.EntityFrameworkCore;
namespace MyTraceTrawler.Services
{
    public static class PrintService
    {
        public static void PrintInfo(string header)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write('i');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(header);

            Console.ResetColor();
        }

        public static void PrintSuccess(string reason = "")
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(((char)0x221A).ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] ");

            if (reason.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(reason);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
            }
            Console.ResetColor();
        }
        public static void PrintFailure(string reason = "")
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write('X');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] ");

            if (reason.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(reason);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed!");
            }
            Console.ResetColor();
        }
        public static void PrintError(Exception error)
        {
            PrintFailure("Exception: " + error.Message);
            PrintFailure("Stack Trace: " + error.StackTrace);
        }
        public static void PrintDbError(DbUpdateException error)
        {
            PrintFailure("DbUpdateException: " + error.Message);
            if (error.InnerException != null)
            {
                PrintFailure("Inner Exception: " + error.InnerException.Message);
                PrintFailure("Inner Exception Stack Trace: " + error.InnerException.StackTrace);
            }
        }
    }
}
