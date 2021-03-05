using System;
using System.IO;

namespace bandwidth_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a filename with extension: ");
            string filename = Console.ReadLine();
            if (File.Exists(filename)) {
                string[] input = File.ReadAllLines(filename);
                string[] sourceAndDestination = input[1].Split(' ');
                string source = sourceAndDestination[0];
                string destination = sourceAndDestination[1];
                
            } else {
                Console.WriteLine("Invalid filename...");
            }
        }
    }
}
