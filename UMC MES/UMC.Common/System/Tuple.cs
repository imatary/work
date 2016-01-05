using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);
    public delegate TResult Func<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);
    public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

    /// <summary>
    /// 
    /// </summary>
    public static class Tuple
    {
        // Methods
        internal static int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), h3);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
        }

        public static Tuple<T> Create<T>(T item)
        {
            return new Tuple<T>(item);
        }

        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }

        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }

        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }

        public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new Tuple<T8>(item8));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Tuple<T> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T _item_;

        // Methods
        public Tuple(T item)
        {
            this._item_ = item;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T> tuple = other as Tuple<T>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            return comparer.Compare(this._item_, tuple._item_);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T> tuple = other as Tuple<T>;
            return ((tuple != null) && comparer.Equals(this._item_, tuple._item_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode(this._item_);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T Item
        {
            get
            {
                return this._item_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 1;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    [Serializable]
    public class Tuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;

        // Methods
        public Tuple(T1 item1, T2 item2)
        {
            this._item1_ = item1;
            this._item2_ = item2;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2> tuple = other as Tuple<T1, T2>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                return comparer.Compare(this._item2_, tuple._item2_);
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2> tuple = other as Tuple<T1, T2>;
            return (((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && comparer.Equals(this._item2_, tuple._item2_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 2;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    [Serializable]
    public class Tuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;
        private readonly T3 _item3_;

        // Methods
        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            this._item1_ = item1;
            this._item2_ = item2;
            this._item3_ = item3;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3> tuple = other as Tuple<T1, T2, T3>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                num = comparer.Compare(this._item2_, tuple._item2_);
                if (num == 0)
                {
                    return comparer.Compare(this._item3_, tuple._item3_);
                }
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3> tuple = other as Tuple<T1, T2, T3>;
            return ((((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && comparer.Equals(this._item2_, tuple._item2_)) && comparer.Equals(this._item3_, tuple._item3_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(", ");
            builder.Append(this._item3_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        public T3 Item3
        {
            get
            {
                return this._item3_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 3;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    [Serializable]
    public class Tuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;
        private readonly T3 _item3_;
        private readonly T4 _item4_;

        // Methods
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this._item1_ = item1;
            this._item2_ = item2;
            this._item3_ = item3;
            this._item4_ = item4;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4> tuple = other as Tuple<T1, T2, T3, T4>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                num = comparer.Compare(this._item2_, tuple._item2_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item3_, tuple._item3_);
                if (num == 0)
                {
                    return comparer.Compare(this._item4_, tuple._item4_);
                }
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4> tuple = other as Tuple<T1, T2, T3, T4>;
            return ((((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && (comparer.Equals(this._item2_, tuple._item2_) && comparer.Equals(this._item3_, tuple._item3_))) && comparer.Equals(this._item4_, tuple._item4_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(", ");
            builder.Append(this._item3_);
            builder.Append(", ");
            builder.Append(this._item4_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        public T3 Item3
        {
            get
            {
                return this._item3_;
            }
        }

        public T4 Item4
        {
            get
            {
                return this._item4_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 4;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;
        private readonly T3 _item3_;
        private readonly T4 _item4_;
        private readonly T5 _item5_;

        // Methods
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this._item1_ = item1;
            this._item2_ = item2;
            this._item3_ = item3;
            this._item4_ = item4;
            this._item5_ = item5;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5> tuple = other as Tuple<T1, T2, T3, T4, T5>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                num = comparer.Compare(this._item2_, tuple._item2_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item3_, tuple._item3_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item4_, tuple._item4_);
                if (num == 0)
                {
                    return comparer.Compare(this._item5_, tuple._item5_);
                }
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5> tuple = other as Tuple<T1, T2, T3, T4, T5>;
            return (((((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && (comparer.Equals(this._item2_, tuple._item2_) && comparer.Equals(this._item3_, tuple._item3_))) && comparer.Equals(this._item4_, tuple._item4_)) && comparer.Equals(this._item5_, tuple._item5_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(", ");
            builder.Append(this._item3_);
            builder.Append(", ");
            builder.Append(this._item4_);
            builder.Append(", ");
            builder.Append(this._item5_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        public T3 Item3
        {
            get
            {
                return this._item3_;
            }
        }

        public T4 Item4
        {
            get
            {
                return this._item4_;
            }
        }

        public T5 Item5
        {
            get
            {
                return this._item5_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 5;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;
        private readonly T3 _item3_;
        private readonly T4 _item4_;
        private readonly T5 _item5_;
        private readonly T6 _item6_;

        // Methods
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            this._item1_ = item1;
            this._item2_ = item2;
            this._item3_ = item3;
            this._item4_ = item4;
            this._item5_ = item5;
            this._item6_ = item6;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5, T6> tuple = other as Tuple<T1, T2, T3, T4, T5, T6>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                num = comparer.Compare(this._item2_, tuple._item2_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item3_, tuple._item3_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item4_, tuple._item4_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item5_, tuple._item5_);
                if (num == 0)
                {
                    return comparer.Compare(this._item6_, tuple._item6_);
                }
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5, T6> tuple = other as Tuple<T1, T2, T3, T4, T5, T6>;
            return (((((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && (comparer.Equals(this._item2_, tuple._item2_) && comparer.Equals(this._item3_, tuple._item3_))) && (comparer.Equals(this._item4_, tuple._item4_) && comparer.Equals(this._item5_, tuple._item5_))) && comparer.Equals(this._item6_, tuple._item6_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(", ");
            builder.Append(this._item3_);
            builder.Append(", ");
            builder.Append(this._item4_);
            builder.Append(", ");
            builder.Append(this._item5_);
            builder.Append(", ");
            builder.Append(this._item6_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        public T3 Item3
        {
            get
            {
                return this._item3_;
            }
        }

        public T4 Item4
        {
            get
            {
                return this._item4_;
            }
        }

        public T5 Item5
        {
            get
            {
                return this._item5_;
            }
        }

        public T6 Item6
        {
            get
            {
                return this._item6_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 6;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6, T7> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;
        private readonly T3 _item3_;
        private readonly T4 _item4_;
        private readonly T5 _item5_;
        private readonly T6 _item6_;
        private readonly T7 _item7_;

        // Methods
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            this._item1_ = item1;
            this._item2_ = item2;
            this._item3_ = item3;
            this._item4_ = item4;
            this._item5_ = item5;
            this._item6_ = item6;
            this._item7_ = item7;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                num = comparer.Compare(this._item2_, tuple._item2_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item3_, tuple._item3_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item4_, tuple._item4_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item5_, tuple._item5_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item6_, tuple._item6_);
                if (num == 0)
                {
                    return comparer.Compare(this._item7_, tuple._item7_);
                }
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7>;
            return (((((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && (comparer.Equals(this._item2_, tuple._item2_) && comparer.Equals(this._item3_, tuple._item3_))) && ((comparer.Equals(this._item4_, tuple._item4_) && comparer.Equals(this._item5_, tuple._item5_)) && comparer.Equals(this._item6_, tuple._item6_))) && comparer.Equals(this._item7_, tuple._item7_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(", ");
            builder.Append(this._item3_);
            builder.Append(", ");
            builder.Append(this._item4_);
            builder.Append(", ");
            builder.Append(this._item5_);
            builder.Append(", ");
            builder.Append(this._item6_);
            builder.Append(", ");
            builder.Append(this._item7_);
            builder.Append(")");
            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        public T3 Item3
        {
            get
            {
                return this._item3_;
            }
        }

        public T4 Item4
        {
            get
            {
                return this._item4_;
            }
        }

        public T5 Item5
        {
            get
            {
                return this._item5_;
            }
        }

        public T6 Item6
        {
            get
            {
                return this._item6_;
            }
        }

        public T7 Item7
        {
            get
            {
                return this._item7_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return 7;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TRest"></typeparam>
    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        // Fields
        private readonly T1 _item1_;
        private readonly T2 _item2_;
        private readonly T3 _item3_;
        private readonly T4 _item4_;
        private readonly T5 _item5_;
        private readonly T6 _item6_;
        private readonly T7 _item7_;
        private readonly TRest _rest_;

        // Methods
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
        {
            if (!(rest is ITuple))
            {
                throw new ArgumentException("the last argument must be a tuple");
            }
            this._item1_ = item1;
            this._item2_ = item2;
            this._item3_ = item3;
            this._item4_ = item4;
            this._item5_ = item5;
            this._item6_ = item6;
            this._item7_ = item7;
            this._rest_ = rest;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
            {
                return 1;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            if (tuple == null)
            {
                throw new ArgumentException("incorrect other tuple type");
            }
            int num = comparer.Compare(this._item1_, tuple._item1_);
            if (num == 0)
            {
                num = comparer.Compare(this._item2_, tuple._item2_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item3_, tuple._item3_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item4_, tuple._item4_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item5_, tuple._item5_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item6_, tuple._item6_);
                if (num != 0)
                {
                    return num;
                }
                num = comparer.Compare(this._item7_, tuple._item7_);
                if (num == 0)
                {
                    return comparer.Compare(this._rest_, tuple._rest_);
                }
            }
            return num;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
            {
                return false;
            }
            Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
            return (((((tuple != null) && comparer.Equals(this._item1_, tuple._item1_)) && (comparer.Equals(this._item2_, tuple._item2_) && comparer.Equals(this._item3_, tuple._item3_))) && ((comparer.Equals(this._item4_, tuple._item4_) && comparer.Equals(this._item5_, tuple._item5_)) && (comparer.Equals(this._item6_, tuple._item6_) && comparer.Equals(this._item7_, tuple._item7_)))) && comparer.Equals(this._rest_, tuple._rest_));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            ITuple tuple = (ITuple)this._rest_;
            if (tuple.Size >= 8)
            {
                return tuple.GetHashCode(comparer);
            }
            switch ((8 - tuple.Size))
            {
                case 1:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));

                case 2:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));

                case 3:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));

                case 4:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));

                case 5:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));

                case 6:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));

                case 7:
                    return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1_), comparer.GetHashCode(this._item2_), comparer.GetHashCode(this._item3_), comparer.GetHashCode(this._item4_), comparer.GetHashCode(this._item5_), comparer.GetHashCode(this._item6_), comparer.GetHashCode(this._item7_), tuple.GetHashCode(comparer));
            }
            return -1;
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        string ITuple.ToString(StringBuilder builder)
        {
            builder.Append(this._item1_);
            builder.Append(", ");
            builder.Append(this._item2_);
            builder.Append(", ");
            builder.Append(this._item3_);
            builder.Append(", ");
            builder.Append(this._item4_);
            builder.Append(", ");
            builder.Append(this._item5_);
            builder.Append(", ");
            builder.Append(this._item6_);
            builder.Append(", ");
            builder.Append(this._item7_);
            builder.Append(", ");
            return ((ITuple)this._rest_).ToString(builder);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            return ((ITuple)this).ToString(builder);
        }

        // Properties
        public T1 Item1
        {
            get
            {
                return this._item1_;
            }
        }

        public T2 Item2
        {
            get
            {
                return this._item2_;
            }
        }

        public T3 Item3
        {
            get
            {
                return this._item3_;
            }
        }

        public T4 Item4
        {
            get
            {
                return this._item4_;
            }
        }

        public T5 Item5
        {
            get
            {
                return this._item5_;
            }
        }

        public T6 Item6
        {
            get
            {
                return this._item6_;
            }
        }

        public T7 Item7
        {
            get
            {
                return this._item7_;
            }
        }

        public TRest Rest
        {
            get
            {
                return this._rest_;
            }
        }

        int ITuple.Size
        {
            get
            {
                return (7 + ((ITuple)this._rest_).Size);
            }
        }
    }
}