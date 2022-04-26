using System;

namespace IteratorPattern;

class IteratorExampleApp
{
  static void Main(string[] args)
  {
     NumberArray array = new NumberArray();
     array.Fill(100);

     ForwardIterator fit = new ForwardIterator(array);
     while (!fit.IsDone())
     {
        Console.Write($"{fit.Current()} ");
        fit.Next();
     }
     Console.WriteLine();

     ReverseIterator rit = new ReverseIterator(array);
     while (!rit.IsDone())
     {
        Console.Write($"{rit.Current()} ");
        rit.Next();
     }
     Console.WriteLine();
  }
}
