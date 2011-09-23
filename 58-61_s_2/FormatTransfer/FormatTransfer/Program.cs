using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up the file for input and output
            System.IO.StreamReader InputFile   = new System.IO.StreamReader(@"D:\Projects\Jack\58-61_s_2\58-61_s_2.fastq");
            System.IO.StreamWriter OutputFile1 = new System.IO.StreamWriter(@"D:\Projects\Jack\58-61_s_2\Left.fastq");
            System.IO.StreamWriter OutputFile2 = new System.IO.StreamWriter(@"D:\Projects\Jack\58-61_s_2\Right.fastq");
            System.IO.StreamWriter OutputFile3 = new System.IO.StreamWriter(@"D:\Projects\Jack\58-61_s_2\Reverse Right.fastq");
            // Read Data from the old formate
            int count,SeqLength;
            string line, Leftpart, Rightpart;
            char[] ReverseRight;
            count = 1;

            while ((line = InputFile.ReadLine()) != null)
            {
                // The 1st line should be "@+sequence identifer"
                if (line[0] != '@')
                {
                    Console.WriteLine(line);
                    Console.WriteLine("The beginning of Line {0} is not @", count);
                    break;
                }
                OutputFile1.WriteLine(line);
                OutputFile2.WriteLine(line);
                OutputFile3.WriteLine(line);
                count++;

                // The 2nd line should be the raw sequence data
                if ((line = InputFile.ReadLine()) != null)
                {
                    SeqLength = line.Length / 2;
                    Leftpart = line.Substring(0, SeqLength-1);
                    Rightpart = line.Substring(SeqLength+1);
                    ReverseRight = Rightpart.ToArray();
                    Array.Reverse(ReverseRight);
                    
                    OutputFile1.WriteLine(Leftpart);
                    OutputFile2.WriteLine(Rightpart);
                    OutputFile3.WriteLine(ReverseRight);

                    count++;
                }

                // The 3rd line should begin with +
                if ((line = InputFile.ReadLine()) != null)
                {
                    if (line[0] != '+')
                    {
                        Console.WriteLine("The beginning of Line {0} is not +", count);
                        break;
                    }
                    OutputFile1.WriteLine(line);
                    OutputFile2.WriteLine(line);
                    OutputFile3.WriteLine(line);
                    count++;
                }

                // The 4nd line should record the quality of the sequence data 
                if ((line = InputFile.ReadLine()) != null)
                {
                    SeqLength = line.Length / 2;
                    Leftpart = line.Substring(0, SeqLength - 1);
                    Rightpart = line.Substring(SeqLength + 1);
                    ReverseRight = Rightpart.ToArray();
                    Array.Reverse(ReverseRight);

                    OutputFile1.WriteLine(Leftpart);
                    OutputFile2.WriteLine(Rightpart);
                    OutputFile3.WriteLine(ReverseRight);

                    count++;
                }
                
            }

            InputFile.Close();
            OutputFile1.Close();
            OutputFile2.Close();
            OutputFile3.Close();
            Console.WriteLine("Job Done!");
            Console.ReadLine();
        }
    }
}
