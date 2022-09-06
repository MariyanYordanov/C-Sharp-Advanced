using System;
using System.Runtime;
namespace Exeption
{
    class Exception
    {
        static void Main(string[] args)
        {
            double number = default;
            try
            {
                string line = Console.ReadLine();
                bool tryDouble = double.TryParse(line, out number);
                number = Math.Sqrt(number);
            }
            catch (ArgumentNullException)
            {
                if (number != default)
                {
                    throw new ArgumentNullException("Invalid number");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                if (number <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number");
                }
            }
            finally
            {
                Console.WriteLine(number);
                Console.WriteLine("Good Bye");
            }
        }
    }
}
