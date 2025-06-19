using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingtheFactoryMethodPattern
{
    //creating an interface IDocument that will be implemented by all the document types
    public interface IDocument
    {
        void open();
        void save();
        void print();

    }

    //creating different document types that implement the IDocument interface
    public class WordDocument : IDocument
    {
        public WordDocument()
        {
            Console.WriteLine("Word Document initialized");
        }
        public void open()
        {
            Console.WriteLine("Word Document opened");
        }
        public void save()
        {
            Console.WriteLine("Word Document saved");
        }
        public void print()
        {
            Console.WriteLine("Word Document printed");
        }

    }

    public class PdfDocument : IDocument
    {
        public PdfDocument()
        {
            Console.WriteLine("PDF Document initialized");
        }
        public void open()
        {
            Console.WriteLine("PDF Document opened");
        }
        public void save()
        {
            Console.WriteLine("PDF Document saved");
        }
        public void print()
        {
            Console.WriteLine("PDF Document printed");
        }
    }

    public class ExcelDocument : IDocument
    {
        public ExcelDocument()
        {
            Console.WriteLine("Excel Document initialized");
        }
        public void open()
        {
            Console.WriteLine("Excel Document opened");
        }
        public void save()
        {
            Console.WriteLine("Excel Document saved");
        }
        public void print()
        {
            Console.WriteLine("Excel Document printed");
        }
    }

    //The DocumentFactory class is an abstract class that defines the factory method CreateDocument
    public abstract class DocumentFactory
    {
        //im creating a abstract method... here i mentioned iDocument because i want to return the interface as the return type
        public abstract IDocument CreateDocument();

        //this method uses the factory method to create a document and perform operations on it
        public void openAndPrint()
        {
            //here doc is the interface type, and CreateDocument is the method that returns the interface type
            IDocument doc = CreateDocument();
            doc.open();
            doc.print();
        }
    }

    //the concrete factory classes inherit from DocumentFactory and implement the CreateDocument method..
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Method Pattern..\n");
            Console.WriteLine("Enter document type to create document (word/pdf/excel):");

            String input = Console.ReadLine().Trim().ToLower();

            if (input == null)
            {
                Console.WriteLine("No input. Please enter a valid document type.");
                return;
            }
            //here factory is the abstract class that will be used to create the document
            DocumentFactory factory = null;
            switch(input)
            {
                case "word":
                    //here WordDocumentFactory is the concrete factory that will be used to create the document
                    factory = new WordDocumentFactory();
                    break;
                case "pdf":
                    factory = new PdfDocumentFactory();
                    break;
                case "excel":
                    factory = new ExcelDocumentFactory();
                    break;
                default:
                    Console.WriteLine("Invalid document type. default to word");
                    factory = new WordDocumentFactory();
                    break;
            }
            //factory.openAndPrint();

            //im creating a document object using the factory method..
            IDocument document = factory.CreateDocument();
            //calling the methods on the document object
            document.open();
            document.save();
            document.print();

            Console.WriteLine("Document operations completed successfully.\n");
            Console.ReadLine();
        }
    }
}
