using Common.ThreadSafeStream.Enumerators;
using System.Collections.Generic;

namespace Common.ThreadSafeStream.Interfaces
{
    public interface IThreadSafeStreamWrapper<T>
    {
        public IThreadSafeStream<T> Stream { get; set; }
        public ThreadSafeStreamDirection Direction { get; set; }
    }
}