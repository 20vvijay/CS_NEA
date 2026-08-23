using System.Runtime.InteropServices;
using System.Text;

namespace asynch
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            bool result = int.TryParse(Console.ReadLine(), out int numLetters);
            if (!result)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return 1; // Exit the program if the input is invalid
                // throwException(new ArgumentException("Invalid input. Please enter a valid number."));
                
            }
            var filePath = RepeatAlphabet(numLetters);
            Console.WriteLine("Finished writing to file.");
            Console.WriteLine($"Reading from file: {filePath}");
            ReadingFromFile(filePath);
            Console.WriteLine("Finished reading from file.");
            return 0;
        }

        static string RepeatAlphabet(int n)
        {
            Console.WriteLine("Writing to file...");
            var dateTime = DateTime.Now;
            var fileName = $"TextFile{dateTime:yyyyMMddHHmmss}.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            // using var streamWriter = File.AppendText(filePath);
            // File.AppendAllText(filePath, "");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(((char)('A' + (i % 26))).ToString());
                sb.Append(i.ToString());
            }

            // immutable: cannot be modified after creation
            // mutable: can be modified after creation
            File.AppendAllText(filePath, sb.ToString());

            Console.WriteLine("Finished writing to file.");
            return filePath;
        }

        static void ReadingFromFile(string filePath)
        {
           using var streamReader = new StreamReader(filePath);
           string? line = streamReader.ReadLine();
           while (line != null)
           {
               Console.WriteLine(line);
               line = streamReader.ReadLine();
           }
        }

    }
}
