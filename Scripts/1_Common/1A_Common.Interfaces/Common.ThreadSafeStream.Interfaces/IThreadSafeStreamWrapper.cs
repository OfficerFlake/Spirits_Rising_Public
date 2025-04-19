using Common.ThreadSafeStream.Enumerators;
using System.Collections.Generic;

namespace Common.ThreadSafeStream.Interfaces
{
    public interface IThreadSafeStreamWrapper<T>
    {
        public IThreadSafeStream<T> Stream { get; }
        public ThreadSafeStreamDirection Direction { get; }
        public T Value { get; set; }
    }
}