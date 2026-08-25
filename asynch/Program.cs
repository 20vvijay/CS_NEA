using System.Runtime.InteropServices;
using System.Text;

namespace asynch
{
    //public class Animal
    //{
        
    //}

    //public class Cat
    //{
        
    //}
    
    //public class Duck
    //{

    //}
    
    // implementing a list as a generic

    public class Tree<T>
    {
        public T GetLeftNote()
        {
            return LeftNode;
        }

        public void SetLeftNote(T value)
        {
            LeftNode = value;
        }

        public T LeftNode { get; private set; }

        public T RightNode { get; set; }

        // auto property = no backing field
        // full property = has a backing field
        // backing field = a private variable that stores the value of a property

    }

    //public interface ISwimmable
    //{
    //    void Swim();
    //}

    public class Flyable<T> where T : new()
    {
      public T GetObject()
        {
            return new T();
        }

        public int GetInt()
        {
            return 0;
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var left1 = tree.LeftNote;
            //tree.LeftNote = 10;

            Console.WriteLine("Hello, World!");

            bool result = int.TryParse(Console.ReadLine(), out int numLetters);
            if (!result)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return; // Exit the program if the input is invalid
                // throwException(new ArgumentException("Invalid input. Please enter a valid number."));
                
            }

            var dateTime = DateTime.Now;
            var fileName = $"TextFile{dateTime:yyyyMMddHHmmss}.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            //var (filePath, task) = RepeatAlphabet(numLetters);
            RepeatAlphabetAsync(numLetters * 3, filePath);
            //while (!task.IsCompleted)
            //{
            //    Console.WriteLine("Waiting for the file writing to complete...");
            //    Thread.Sleep(1000); // Wait for 1 second before checking again
            //}
            await ReadingFromFileAsync(filePath);
            
            RepeatAlphabetAsync(numLetters, filePath);
            await ReadingFromFileAsync(filePath);
            
            Console.ReadLine();
            
            return;
        }
        

        static async Task RepeatAlphabetAsync(int n, string filePath)
        {
            Console.WriteLine("Writing to file...");
            
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

            await File.AppendAllTextAsync(filePath, sb.ToString());

            Console.WriteLine("Finished writing to file.");
        }

        //static (string, Task) RepeatAlphabet(int n)
        //{
        //    Console.WriteLine("Writing to file...");
        //    var dateTime = DateTime.Now;
        //    var fileName = $"TextFile{dateTime:yyyyMMddHHmmss}.txt";
        //    string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        //    // using var streamWriter = File.AppendText(filePath);
        //    // File.AppendAllText(filePath, "");
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < n; i++)
        //    {
        //        sb.Append(((char)('A' + (i % 26))).ToString());
        //        sb.Append(i.ToString());
        //    }

        //    // immutable: cannot be modified after creation
        //    // mutable: can be modified after creation
            
        //    var task = File.AppendAllTextAsync(filePath, sb.ToString());
            

        //    Console.WriteLine("Finished writing to file.");
        //    return (filePath, task);
        //}

        static async Task ReadingFromFileAsync(string filePath)
        {
            Console.WriteLine($"Reading from file: {filePath}");
            
            try
            {
                
                using var streamReader = new StreamReader(filePath);
                string? line = await streamReader.ReadLineAsync();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = await streamReader.ReadLineAsync();
                }
                Console.WriteLine("Finished reading from file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
                Console.WriteLine(ex.ToString());
            }

            // deadlock: when two or more threads are waiting for each other to release a resource, and none of them can proceed, resulting in a standstill.

        }

    }
}
