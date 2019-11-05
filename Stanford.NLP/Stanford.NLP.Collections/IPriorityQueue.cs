using System;
using System.Collections.Generic;
using System.Text;

namespace Stanford.NLP.Collections
{
    public interface IPriorityQueue<TElement> : ISet<TElement>
    {
        TElement RemoveFirst();

        TElement GetFirst();

        double GetPriority();

        double GetPriority(TElement key);

        bool Add(TElement key, double priority);

        bool ChangePriority(TElement key, double priority);

        bool RelaxPriority(TElement key, double priority);

        IList<TElement> ToSortedList();

        string ToString(int maxKeysToPrint);
    }
}
