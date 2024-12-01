﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Multithreading_using_parallel_process
{
    class MultiThreading
    {
        static void Main(string[] args)
        {
            //Indicates the number of threads to be create.
            int limit = 5;
            Console.WriteLine("Parallel For Loop");
            Parallel.For(0, limit, count =>
            {
                Console.WriteLine("Task {0} started", count);
                //Create multiple presentations, one PPT on each thread.
                OpenAndSaveWordDocument(count);
                Console.WriteLine("Task {0} is done", count);
            });
        }
        //Create a Word document using multi-threading.
        static void OpenAndSaveWordDocument(int count)
        {
            using (FileStream inputStream = new FileStream(Path.GetFullPath(@"Data/InputTemplate.docx"), FileMode.Open, FileAccess.Read))
            {
                // Load the Word document
                using (WordDocument document = new WordDocument(inputStream, FormatType.Docx))
                {
                    // Save the Word document in the desired format
                    using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output/Output" + count + ".docx"), FileMode.Create, FileAccess.Write))
                    {
                        document.Save(outputFileStream, FormatType.Docx);
                    }
                }
            }
        }
    }
}
