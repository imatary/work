using System.Collections;
using System.Text;

namespace System
{
    public interface ITuple
    {
        // Methods
        int GetHashCode(IEqualityComparer comparer);
        string ToString(StringBuilder builder);

        // Properties
        int Size { get; }

    }
}