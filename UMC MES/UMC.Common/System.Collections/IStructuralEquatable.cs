namespace System.Collections
{
    public interface IStructuralEquatable
    {
        // Methods
        bool Equals(object other, IEqualityComparer comparer);
        int GetHashCode(IEqualityComparer comparer);

    }
}