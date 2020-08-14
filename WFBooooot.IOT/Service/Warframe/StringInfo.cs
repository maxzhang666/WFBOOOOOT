using System;
using System.Collections.Generic;

namespace WFBooooot.IOT.Service.Warframe
{
    internal class StringInfo : IComparable<StringInfo>, IComparable
    {
        public string Name { get; set; }
        public int LevDistance { get; set; }

        public int CompareTo(StringInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return LevDistance.CompareTo(other.LevDistance);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is StringInfo other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(StringInfo)}");
        }

        public static bool operator <(StringInfo left, StringInfo right)
        {
            return Comparer<StringInfo>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(StringInfo left, StringInfo right)
        {
            return Comparer<StringInfo>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(StringInfo left, StringInfo right)
        {
            return Comparer<StringInfo>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(StringInfo left, StringInfo right)
        {
            return Comparer<StringInfo>.Default.Compare(left, right) >= 0;
        }
    }
}