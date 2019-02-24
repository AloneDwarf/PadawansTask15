using System;
using System.Collections.Generic;
using System.Linq;

namespace PadawansTask15
{
    public class EnumerableTask
    {
        /// <summary> Transforms all strings to upper case.</summary>
        /// <param name="data">Source string sequence.</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase.
        /// </returns>
        /// <example>
        ///    {"a", "b", "c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            List<string> list = new List<string>();
            IEnumerator<string> ie = data.GetEnumerator();
            while (ie.MoveNext())   // пока не будет возвращено false
            {
                if (ie.Current == "" || ie.Current == null)
                {
                    list.Add(ie.Current);
                    continue;
                }
                list.Add(ie.Current.ToUpper());     // берем элемент на текущей позиции
            }
            ie.Reset();
            return list;
            //throw new NotImplementedException();
        }

        /// <summary> Transforms an each string from sequence to its length.</summary>
        /// <param name="data">Source strings sequence.</param>
        /// <returns>
        ///   Returns sequence of strings length.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a", "aa", "aaa" } => { 1, 2, 3 }
        ///   {"aa", "bb", "cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public  IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            List<int> list = new List<int>();
            IEnumerator<string> ie = data.GetEnumerator();
            while (ie.MoveNext())   // пока не будет возвращено false
            {
                if (ie.Current == "" || ie.Current == null)
                {
                    list.Add(0);
                    continue;
                }
                list.Add(ie.Current.Length);     // берем элемент на текущей позиции
            }
            ie.Reset();
            return list;
        }

        /// <summary>Transforms integer sequence to its square sequence, f(x) = x * x. </summary>
        /// <param name="data">Source int sequence.</param>
        /// <returns>
        ///   Returns sequence of squared items.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public  IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            List<long> list = new List<long>();
            IEnumerator<int> ie = data.GetEnumerator();
            while (ie.MoveNext())   // пока не будет возвращено false
            {
                list.Add((long)ie.Current * (long)ie.Current);     // берем элемент на текущей позиции
            }
            ie.Reset();
            return list;
            // TODO : Implement GetSquareSequence
            //throw new NotImplementedException();
        }

        /// <summary> Filters a string sequence by a prefix value (case insensitive).</summary>
        /// <param name="data">Source string sequence.</param>
        /// <param name="prefix">Prefix value to filter.</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive).
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when prefix is null.</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix = "D"  => { }
        ///  { "a","b","c" }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix = null => ArgumentNullException
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            if (data == null || prefix == null)
                throw new ArgumentNullException();
            List<string> prefixItems = new List<string>();
            foreach (string item in data)
            {
                if (item == null) continue;
                if (prefix == string.Empty && item != null)
                {
                    prefixItems.Add(item);
                    continue;
                }
                //if(ie.Current.Substring(0,prefix.Length) == prefix)
                if (item.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                    prefixItems.Add(item);
            }
            return prefixItems;
            // TODO : Implement GetPrefixItems
            //throw new NotImplementedException();
        }

        /// <summary> Finds the 3 largest numbers from a sequence.</summary>
        /// <param name="data">Source sequence.</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3LargestItems(IEnumerable<int> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            IEnumerator<int> ie = data.GetEnumerator();
            int i = 0;
            int max = 0;
            while (ie.MoveNext())   // пока не будет возвращено false
            {
                list1.Add(ie.Current);
            }
            while (i < 3)
            {
                if (list1.Count == 0)
                    break;
                max = list1[0];
                foreach (int j in list1)
                    if (j > max)
                        max = j;
                list2.Add(max);
                list1.Remove(max);
                i++;
            }
            return list2;
            // TODO : Implement Get3LargestItems
            //throw new NotImplementedException();
        }

        /// <summary> Calculates sum of all integers from object array.</summary>
        /// <param name="data">Source array.</param>
        /// <returns>
        ///    Returns the sum of all integers from object array.
        /// </returns>
        /// <example>
        ///    { 1, true, "a", "b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllIntegers(object[] data)
        {
            int res = 0;
            foreach (object i in data)
            {
                if (i == null)
                    continue;
                if (i.GetType().Equals(typeof(int)))
                    res += (int)i;
            }
            return res;
            // TODO : Implement GetSumOfAllIntegers
            //throw new NotImplementedException();
        }
    }
}