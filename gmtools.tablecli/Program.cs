using gmtools.rolltables;
using System;
using System.Globalization;

namespace gmtools.tablecli
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Table Name (or 'exit' to exit): ");
                var tableName = Console.ReadLine().ToLower(CultureInfo.InvariantCulture);

                if (tableName.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                var table = TableFactory.GetTableByName(tableName);
                var result = table.Roll();

                Console.WriteLine("Result:");
                Console.WriteLine(result.Temp);
                Console.WriteLine("");
            }
        }
    }
}
