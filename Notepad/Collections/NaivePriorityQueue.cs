//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Text;

//namespace Notepad.Collections
//{
//    class NaivePriorityQueue
//    {
//        public int Count => _arr.Length;
//        public int this[int ind]
//        {
//            return _arr[ind];
//        }
//        public NaivePriorityQueue(int size)
//        {
//            _arr = new int[size];
//        }

//        public void Add(int a)
//        {
//            for (int i = 0; i < _arr.Length; i++)
//            {
//                // comparator
//                if (_arr[i] < a)
//                {
//                    Shift(i);
//                    _arr[i] = a;
//                    break;
//                }
//            }
//        }

//        private void Shift(int ind)
//        {
//            for (int i = ind; i < _arr.Length - 1; i++)
//            {
//                _arr[i + 1] = _arr[i];
//            }
//        }
//    }
//}
