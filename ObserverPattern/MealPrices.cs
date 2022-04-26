using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
   public abstract class Observable
   {
      protected List<IObserver> _observers = new List<IObserver>();

      public virtual void Attach(IObserver observer)
      {
         _observers.Add(observer);
      }

      public virtual void Detach(IObserver observer)
      {
         _observers.Remove(observer);
      }

      public virtual void Notify()
      {
         _observers.ForEach(o => o.Update());
      }
   }

   public class MealPrices : Observable
   {
      private decimal _breakfastPrice;
      private decimal _lunchPrice;
      private decimal _dinnerPrice;

      public decimal BreakfastPrice
      {
         get => _breakfastPrice;
         set
         {
            _breakfastPrice = value;
            Notify();
         }
      }

      public decimal LunchPrice
      {
         get => _lunchPrice;
         set
         {
            _lunchPrice = value;
            Notify();
         }
      }

      public decimal DinnerPrice
      {
         get => _dinnerPrice;
         set
         {
            _dinnerPrice = value;
            Notify();
         }
      }
   }

   public interface IObserver
   {
      void Update();
   }

   public class MealPriceView : IObserver
   {
      private readonly MealPrices _mealPrices;

      public MealPriceView(MealPrices mealPrices)
      {
         _mealPrices = mealPrices;
      }

      public void Update()
      {
         Console.SetCursorPosition(40, 1);
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.Write("+--------------------------------+");
         Console.SetCursorPosition(40, 2);
         Console.Write("|                                |");
         Console.SetCursorPosition(40, 3);
         Console.Write("|                                |");
         Console.SetCursorPosition(40, 4);
         Console.Write("|                                |");
         Console.SetCursorPosition(40, 5);
         Console.Write("+--------------------------------+");

         Console.ForegroundColor = ConsoleColor.Red;
         Console.SetCursorPosition(42, 2);
         Console.Write($"Breakfast Price: {_mealPrices.BreakfastPrice:C}");
         Console.SetCursorPosition(42, 3);
         Console.Write($"Lunch Price: {_mealPrices.LunchPrice:C}");
         Console.SetCursorPosition(42, 4);
         Console.Write($"Dinner Price: {_mealPrices.DinnerPrice:C}");

         Console.SetCursorPosition(40, 10);

      }
   }
}
