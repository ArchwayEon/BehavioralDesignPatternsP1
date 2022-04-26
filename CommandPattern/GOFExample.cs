using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.GOF
{
   public abstract class Command
   {
      protected readonly Application _app;

      public Command(Application app)
      {
         _app = app;
      }
      
      public abstract void Execute();
   }

   public class OpenCommand : Command
   {
      public OpenCommand(Application app) : base(app)
      {
      }

      public override void Execute()
      {
         string filename = _app.AskUser("Enter the filename to open: ");
         Document document = new Document(filename);
         _app.Add(document);
      }
   }

   public class DeleteCommand : Command
   {
      public DeleteCommand(Application app) : base(app)
      {
      }

      public override void Execute()
      {
         string filename = _app.AskUser("Enter the filename to delete: ");
         string answer = _app.AskUser("Are your sure (Y/N)? ");
         if(answer == "Y")
         {
            _app.Delete(filename);
         }
      }
   }

   public class ShowAllCommand : Command
   {
      public ShowAllCommand(Application app) : base(app)
      {
      }

      public override void Execute()
      {
         foreach(Document document in _app.Documents)
         {
            Console.WriteLine(document.FileName);
         }
      }
   }

   public class Document
   {
      public string FileName { get; }

      public Document(string filename)
      {
         FileName = filename;
      }
   }

   public class Application
   {
      public List<Document> Documents { get; private set; }
         = new List<Document>();

      public string AskUser(string prompt)
      {
         Console.Write(prompt);
         return Console.ReadLine();
      }

      public void Add(Document document)
      {
         Documents.Add(document);
      }

      internal void Delete(string filename)
      {
         Document documentToDelete = 
            Documents.FirstOrDefault(d => d.FileName == filename);
         if(documentToDelete != null)
         {
            Documents.Remove(documentToDelete);
         }
      }
   }
}
