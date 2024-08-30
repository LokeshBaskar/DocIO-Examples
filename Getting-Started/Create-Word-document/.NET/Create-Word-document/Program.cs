﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.IO;

namespace Create_Word_document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a new instance of WordDocument (Empty Word Document).
            using (WordDocument document = new WordDocument())
            {
                //Adds a section and a paragraph to the document.
                document.EnsureMinimal();
                //Appends text to the last paragraph of the document.
                document.LastParagraph.AppendText("Hello World");
                //Creates file stream.
                using (FileStream fileStream = new FileStream(Path.GetFullPath(@"Output/Result.docx"), FileMode.Create, FileAccess.ReadWrite))
                {
                    //Saves the Word document to file stream.
                    document.Save(fileStream, FormatType.Docx);
                }
            }
        }
    }
}
