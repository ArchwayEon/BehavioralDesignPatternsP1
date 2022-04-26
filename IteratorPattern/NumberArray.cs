using System;
using System.Linq;

namespace IteratorPattern;

public class NumberArray
{
    private readonly int[] _numbers;
    private readonly Random _random = new Random();

    public int Size
    {
        get
        {
            return _numbers.Length;
        }
    }

    public int this[int i]
    {
        get { return _numbers[i]; }
    }

    public NumberArray(int size = 10)
    {
        _numbers = new int[size];
    }

    public void Fill(int maxValue)
    {
        for (int i = 0; i < _numbers.Length; i++)
        {
            _numbers[i] = _random.Next(1, maxValue + 1);
        }
    }

    public double Average()
    {
        return _numbers.Average();
    }

    public int Smallest()
    {
        return _numbers.Min();
    }

    public int Largest()
    {
        return _numbers.Max();
    }
}


public abstract class Iterator
{
    public abstract int First();
    public abstract int Next();
    public abstract bool IsDone();
    public abstract int Current();
}

public class ForwardIterator : Iterator
{
    private readonly NumberArray _numberArray;
    private int _index = 0;

    public ForwardIterator(NumberArray numberArray)
    {
        _numberArray = numberArray;
        First();
    }

    public override int Current()
    {
        return _numberArray[_index];
    }

    public override int First()
    {
        _index = 0;
        return Current();
    }

    public override bool IsDone()
    {
        return _index > _numberArray.Size - 1;
    }

    public override int Next()
    {
        _index++;
        if (IsDone())
        {
            return _numberArray[_numberArray.Size - 1];
        }
        return Current();
    }
}

public class ReverseIterator : Iterator
{
    private readonly NumberArray _numberArray;
    private int _index;

    public ReverseIterator(NumberArray numberArray)
    {
        _numberArray = numberArray;
        First();
    }

    public override int Current()
    {
        return _numberArray[_index];
    }

    public override int First()
    {
        _index = _numberArray.Size - 1;
        return Current();
    }

    public override bool IsDone()
    {
        return _index < 0;
    }

    public override int Next()
    {
        _index--;
        if (IsDone())
        {
            return _numberArray[0];
        }
        return Current();
    }
}

