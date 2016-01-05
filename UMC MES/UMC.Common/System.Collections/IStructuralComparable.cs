namespace System.Collections
{
    public interface IStructuralComparable
    {
        // Methods
        int CompareTo(object other, IComparer comparer);
    }
}