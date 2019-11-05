using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Stanford.NLP.Collections
{
    public class BinaryHeapPriorityQueue<TElement> : ISet<TElement>, IPriorityQueue<TElement>
    {
        /// <summary>
        /// Wraps a <typeparamref name="TElement"/> to provide Index and Priority information.
        /// </summary>
        private sealed class Entry
        {
            private static readonly Lazy<bool> isComparable
                = new Lazy<bool>(() => typeof(IComparable).IsAssignableFrom(typeof(TElement)));

            private static bool IsComparable => isComparable.Value;

            public TElement Key { get; set; }

            public int Index { get; set; }

            public double Priority { get; set; }

            public override string ToString() => $"{Key} at {Index} ({Priority})";

            public int Compare(Entry entry)
            {
                {
                    var result = Compare(Priority, entry.Priority);
                    if (result != 0)
                        return result;
                    if (IsComparable)
                        return (Key as IComparable).CompareTo(entry.Key);
                    return result;
                }
            }

            private static int Compare(double a, double b)
            {
                var diff = a - b;
                if (diff > 0.0)
                    return 1;
                if (diff < 0.0)
                    return -1;
                return 0;
            }
        }

        private readonly HashSet<TElement> backingSet
            = new HashSet<TElement>();

        /// <summary>
        /// Maps linear array location (not priorities) to heap entries.
        /// </summary>
        private readonly List<Entry> indexToEntry
            = new List<Entry>();

        /// <summary>
        /// Maps heap objects to their heap entries.
        /// </summary>
        private readonly Dictionary<TElement, Entry> keyToEntry
            = new Dictionary<TElement, Entry>();

        #region IPriorityQueue Implementation

        /// <summary>
        /// Finds the <typeparamref name="TElement"/> with the highest priority, removes it, and returns.
        /// </summary>
        /// <returns>The <typeparamref name="TElement"/> with the highest priority.</returns>
        public TElement RemoveFirst() => throw new NotImplementedException();

        /// <summary>
        /// Finds the <typeparamref name="TElement"/> with the highest priority and returns it, without modifying the queue.
        /// </summary>
        /// <returns>The <typeparamref name="TElement"/> with minimum key.</returns>
        public TElement GetFirst() => backingSet.Count > 0
            ? GetEntry(0).Key
            : throw new InvalidOperationException("The collection is empty.");

        /// <summary>
        /// Finds the <typeparamref name="TElement"/> with the highest priority and returns its priority, without modifying the queue.
        /// </summary>
        /// <returns>The maximum Priority.</returns>
        public double GetPriority() => backingSet.Count > 0
            ? GetEntry(0).Priority
            : throw new InvalidOperationException($"The collection is empty.");

        /// <summary>
        /// Searches for the provided <paramref name="key"/> and returns its Priority.
        /// </summary>
        /// <param name="key">The element to search for.</param>
        /// <returns>The Priority of the provided <paramref name="key"/>, if it exists.</returns>
        public double GetPriority(TElement key)
        {
            var entry = GetEntry(key);
            if (entry == default)
                return double.NegativeInfinity;
            return entry.Priority;
        }

        /// <summary>
        /// Adds an object to the Queue with the provided <paramref name="priority"/>.
        /// </summary>
        /// <param name="key">Value to add.</param>
        /// <param name="priority">Priority value to assign.</param>
        /// <returns>Whether the key was present before.</returns>
        public bool Add(TElement key, double priority)
        {
            if(Add(key))
            {
                RelaxPriority(key, priority);
                return true;
            }
            return false;
        }

        public bool ChangePriority(TElement key, double priority) => throw new NotImplementedException();
        public bool RelaxPriority(TElement key, double priority) => throw new NotImplementedException();
        public IList<TElement> ToSortedList() => throw new NotImplementedException();
        public string ToString(int maxKeysToPrint) => throw new NotImplementedException();

        #endregion

        #region ISet Implementation
        
        /// <summary>
        /// Adds an object to the Queue with the minimum priority (<see cref="double.NegativeInfinity"/>).
        /// </summary>
        /// <remarks>
        /// If the object is already in the queue with worse priority, this does nothing.
        /// If the object is already present, with better priority, it will NOT cause a decrease in priority.
        /// </remarks>
        /// <param name="item">Value to add.</param>
        /// <returns>Whether the key was present before.</returns>
        public bool Add(TElement item)
        {
            if (!backingSet.Add(item))
                return false;
            MakeEntry(item);
            return true;
        }

        public void ExceptWith(IEnumerable<TElement> other) => backingSet.ExceptWith(other);
        public void IntersectWith(IEnumerable<TElement> other) => backingSet.IntersectWith(other);
        public bool IsProperSubsetOf(IEnumerable<TElement> other) => backingSet.IsProperSubsetOf(other);
        public bool IsProperSupersetOf(IEnumerable<TElement> other) => backingSet.IsProperSupersetOf(other);
        public bool IsSubsetOf(IEnumerable<TElement> other) => backingSet.IsSubsetOf(other);
        public bool IsSupersetOf(IEnumerable<TElement> other) => backingSet.IsSupersetOf(other);
        public bool Overlaps(IEnumerable<TElement> other) => backingSet.Overlaps(other);
        public bool SetEquals(IEnumerable<TElement> other) => backingSet.SetEquals(other);
        public void SymmetricExceptWith(IEnumerable<TElement> other) => backingSet.SymmetricExceptWith(other);
        public void UnionWith(IEnumerable<TElement> other) => backingSet.UnionWith(other);
        void ICollection<TElement>.Add(TElement item) => backingSet.Add(item);
        public void Clear() => backingSet.Clear();
        public bool Contains(TElement item) => backingSet.Contains(item);
        public void CopyTo(TElement[] array, int arrayIndex) => backingSet.CopyTo(array, arrayIndex);
        public bool Remove(TElement item) => backingSet.Remove(item);

        public int Count => backingSet.Count;

        public bool IsReadOnly => ((ISet<TElement>)backingSet).IsReadOnly;

        public IEnumerator<TElement> GetEnumerator() => ((ISet<TElement>)backingSet).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((ISet<TElement>)backingSet).GetEnumerator();
        #endregion

        /// <summary>
        /// Searches for the <paramref name="key"/> in the Queue and returns it.
        /// </summary>
        /// <remarks>
        /// May be useful if you can create a new object that is .Equals() to an object in the queue but is not actually identical,
        /// or if you want to modify an object that is in the queue.
        /// </remarks>
        /// <param name="key">The element to search for.</param>
        /// <returns>The matching <typeparamref name="TElement"/> from the Queue, or <see cref="default"/>.</returns>
        public TElement GetObject(TElement key)
            => Contains(key)
            ? GetEntry(key).Key
            : default;

        private static int ParentIndex(int index)
            => (index - 1) / 2;

        private static int LeftChildIndex(int index)
            => index * 2 + 1;

        private static int RightChildIndex(int index)
            => index * 2 + 2;

        private Entry Parent(Entry entry) => GetRelated(entry.Index, ParentIndex, i => i > 0);
        //=> entry.Index > 0
        //? GetEntry(ParentIndex(entry.Index))
        //: null;

        private Entry LeftChild(Entry entry) => GetRelated(entry.Index, LeftChildIndex, i => i < Count);
        //{
        //    var leftIndex = LeftChildIndex(entry.Index);
        //    return leftIndex < Count
        //        ? GetEntry(leftIndex)
        //        : null;
        //}
        
        private Entry RightChild(Entry entry) => GetRelated(entry.Index, RightChildIndex, i => i < Count);
        //{
        //    var rightIndex = RightChildIndex(entry.Index);
        //    return rightIndex < Count
        //        ? GetEntry(rightIndex)
        //        : null;
        //}

        private Entry GetRelated(int index, Func<int, int> newIndex, Func<int, bool> predicate)
            => predicate(newIndex(index)) ? GetEntry(newIndex(index)) : null;

        private void Swap(Entry entryA, Entry entryB)
        {
            var indexA = entryA.Index;
            var indexB = entryB.Index;
            entryA.Index = indexB;
            entryB.Index = indexA;
            indexToEntry[indexA] = entryB;
            indexToEntry[indexB] = entryA;
        }

        public void RemoveLastEntry()
        {
            var entry = indexToEntry[Count - 1];
            keyToEntry.Remove(entry.Key);
            indexToEntry.Remove(entry);
            backingSet.Remove(entry.Key);
        }

        private Entry GetEntry(TElement key) => keyToEntry[key];

        private Entry GetEntry(int index) => indexToEntry[index];

        private Entry MakeEntry(TElement key)
        {
            var entry = new Entry
            {
                Index = Count,
                Key = key,
                Priority = double.NegativeInfinity
            };
            indexToEntry.Add(entry);
            keyToEntry[key] = entry;
            return entry;
        }
    }
}
