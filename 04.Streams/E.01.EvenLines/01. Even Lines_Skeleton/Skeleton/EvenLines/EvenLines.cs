namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            
            using StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            char[] symbols = { '-', ',', '.', '!', '?' };
            int counter = 0;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (counter % 2 != 0)
                {
                    counter++;
                    continue;
                }

                
                foreach (var symbol in symbols)
                {
                    line = line.Replace(symbol, '@');
                }

                line = string.Join(" ", line.Split().Reverse());

                sb.AppendLine(line);

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
       
    }

}
