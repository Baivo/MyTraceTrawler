using System.Reflection;
using WooliesScraper.Products;

namespace WooliesScraper.Helpers
{
    public static class PrintHelper
    {
        public static void PrintInfoHeader(string header)
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
        public static void PrintSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(((char)0x221A).ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");

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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed!");

            if (reason.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write('X');
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(reason);
            }
            Console.ResetColor();
        }
        public static void PrintPropertyName(string name)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  " + name + ": ");
            Console.ResetColor();
        }

        public static void PrintPropertyValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void PrintNullValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("null");
            Console.ResetColor();
        }
        public static void EnhancedPrintProduct(WooliesProduct product)
        {
            if (product == null)
            {
                PrintInfoHeader("Product not found.");
                return;
            }

            PrintInfoHeader("Product Information");
            PrintProperties(product.Product, 1);

            PrintInfoHeader("Additional Attributes");
            PrintProperties(product.AdditionalAttributes, 1);

            PrintInfoHeader("Country of Origin");
            PrintProperties(product.CountryOfOriginLabel, 1);

            PrintInfoHeader("Nutritional Information");
            if (product.NutritionalInformation != null)
            {
                foreach (var info in product.NutritionalInformation)
                {
                    PrintProperties(info, 1);
                }
            }
            else
            {
                PrintNullValue();
            }

            Console.ResetColor();
        }

        private static void PrintProperties(object obj, int indentLevel)
        {
            if (obj == null)
            {
                PrintNullValue();
                return;
            }

            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                PrintPropertyName(new string(' ', indentLevel * 2) + property.Name);

                if (value == null)
                {
                    PrintNullValue();
                }
                else if (value.GetType().IsClass && !value.GetType().IsAssignableFrom(typeof(string)) && !(value is System.Collections.IEnumerable))
                {
                    Console.WriteLine();
                    PrintProperties(value, indentLevel + 1);
                }
                else if (value is System.Collections.IEnumerable && !(value is string))
                {
                    Console.WriteLine();
                    foreach (var item in (System.Collections.IEnumerable)value)
                    {
                        if (item == null)
                        {
                            PrintNullValue();
                        }
                        else
                        {
                            PrintPropertyValue(new string(' ', (indentLevel + 1) * 4) + item.ToString());
                        }
                    }
                }
                else
                {
                    PrintPropertyValue(value.ToString());
                }
            }
        }
    }
}
