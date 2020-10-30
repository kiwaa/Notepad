using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notepad.Collections
{
    public sealed class NaiveTrie<TValue>
    {
        private NaiveTrieNode _root = new NaiveTrieNode();

        public void Add(IEnumerable<string> key, TValue value)
        {
            _root.Add(key.ToArray(), 0, value);
        }
        public void Remove(IEnumerable<string> key, TValue value)
        {
            _root.Remove(key.ToArray(), 0, value);
        }

        public IEnumerable<TValue> Search(IEnumerable<string> pattern)
        {
            return _root.Search(pattern.ToArray(), 0);
        }

        private class NaiveTrieNode
        {
            private const string AllMatcher = "*";

            private Dictionary<string, NaiveTrieNode> _childs = new Dictionary<string, NaiveTrieNode>();

            private List<TValue>? _values;
            private bool _isLeaf = false;

            public IEnumerable<TValue> Search(string[] key, int keyPosition)
            {
                if (keyPosition >= key.Length)
                {
                    return _isLeaf && _values != null ? _values : (IEnumerable<TValue>)Array.Empty<TValue>();
                }
                var child = key[keyPosition];
                var exact = SearchByKey(key, keyPosition, child); // exact
                var all = SearchByKey(key, keyPosition, AllMatcher); // * matcher
                // add 'local' values if current node is a leaf
                var tmp = exact.Concat(all);
                if (_isLeaf && _values != null)
                    return tmp.Concat(_values);
                return tmp;
            }

            private IEnumerable<TValue> SearchByKey(string[] key, int keyPosition, string currKey)
            {
                if (!_childs.TryGetValue(currKey, out NaiveTrieNode? child))
                {
                    return Array.Empty<TValue>();
                }
                return child.Search(key, keyPosition + 1);
            }

            public void Add(string[] key, int keyPosition, TValue value)
            {
                if (keyPosition >= key.Length)
                {
                    AddValue(value);
                    return;
                }

                var child = key[keyPosition];
                if (!_childs.TryGetValue(child, out NaiveTrieNode? node))
                {
                    node = new NaiveTrieNode();
                    _childs.Add(child, node);
                }
                node.Add(key, keyPosition + 1, value);
            }

            public void Remove(string[] key, int keyPosition, TValue value)
            {
                RemoveValue(value);
                if (keyPosition >= key.Length)
                    return;
                var child = key[keyPosition];
                if (!_childs.TryGetValue(child, out NaiveTrieNode? node))
                    return;
                node.Remove(key, keyPosition + 1, value);
            }

            private void AddValue(TValue value)
            {
                if (_values == null)
                {
                    _values = new List<TValue>();
                    _isLeaf = true;
                }
                _values.Add(value);
            }
            private void RemoveValue(TValue value)
            {
                if (_values == null)
                    return;
                _values.Remove(value);
            }
        }
    }
}
