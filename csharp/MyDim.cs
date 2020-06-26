using System;

namespace CSharp
{
    public interface MyDim
    {
        public int Z => 0;
    }

    public class SomeCSharpClass
    {
        public bool TakeANullableDateTime(DateTime? dt) => dt.HasValue;
    }
}
