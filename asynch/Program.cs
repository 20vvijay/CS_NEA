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
            var (filePath, task) = RepeatAlphabet(numLetters);
            while (!task.IsCompleted)
            {
                Console.WriteLine("Waiting for the file writing to complete...");
                Thread.Sleep(1000); // Wait for 1 second before checking again
            }
            ReadingFromFile(filePath);
            
            Console.ReadLine();
            return 0;
        }

        static (string, Task) RepeatAlphabet(int n)
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
            
            var task = File.AppendAllTextAsync(filePath, sb.ToString());
            

            Console.WriteLine("Finished writing to file.");
            return (filePath, task);
        }

        static void ReadingFromFile(string filePath)
        {
            Console.WriteLine($"Reading from file: {filePath}");
            
            try
            {
                
                using var streamReader = new StreamReader(filePath);
                string? line = streamReader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                }
                Console.WriteLine("Finished reading from file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
                Console.WriteLine(ex.ToString());
            }
           
           
        }

    }
}
