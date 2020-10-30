using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Notepad.Collections
{
    public sealed class NaivePriorityQueue<T>
    {
        private Queue<T>[] _queues;
        private int _count;

        // I think we could try to implement lock free by using ConcurrentQueue
        // and Interlocked.Increment/Decrement for Count
        // but potentially there are issues in dequeu method with straightforward approach
        private object _lock = new object();

        public NaivePriorityQueue(int maxPriority)
        {
            _queues = new Queue<T>[maxPriority + 1];
            for (int i = 0; i <= maxPriority; i++)
                _queues[i] = new Queue<T>();
        }

        public int Count => _count;
        public void Enqueue(int priority, T t)
        {
            if (priority < 0 || _queues.Length < priority)
                throw new ArgumentException("Incorrect priority");
            lock (_lock)
            {
                _count++;
                _queues[priority].Enqueue(t);
            }
        }
        public bool TryDequeue([MaybeNullWhen(false)] out T t)
        {
            t = default;
            if (_count <= 0)
                return false;
            lock (_lock)
            {
                for (int i = _queues.Length - 1; i >= 0; i--)
                {
                    if (_queues[i].Count > 0)
                    {
                        _count--;
                        t = _queues[i].Dequeue();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
