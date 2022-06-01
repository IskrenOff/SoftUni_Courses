namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            ProcessLines(inputFilePath);
        }

        public static void ProcessLines(string inputFilePath)
        {
<<<<<<< HEAD:C# Advance/Steams, Files and Directories/EvenLines/EvenLines.cs
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = -1; // count of rows
                string line = reader.ReadLine();  // read one line from the file

                while (line != null)
                {
                    counter++;

                    if (counter %2 == 0)
                    {
                        line = Replace(line);
                        line = Revarce(line);
                        Console.WriteLine(line);
                    }

                    line = reader.ReadLine();
                }
            }
        }

        private static string Revarce(string line)
        {
            return string.Join (" ", line.Split(' ').Reverse());
        }

        private static string Replace(string line)
        {
            return line.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
=======
            return nameof(EvenLines);
>>>>>>> dc44c8e52735c768f6ecd76e53979fe0773bab3e:C# Advance/Streams, Files and Directories/EvenLines/EvenLines.cs
        }
    }
}
