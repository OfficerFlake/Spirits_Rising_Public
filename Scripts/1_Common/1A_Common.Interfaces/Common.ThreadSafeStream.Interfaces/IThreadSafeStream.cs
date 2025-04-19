using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Common.ThreadSafeStream.Interfaces
{
    public interface IThreadSafeStream<T>
    {
        public List<T> Up { get; set; }
        public List<T> Down { get; set; }

        public IThreadSafeStreamWrapperUnity<T> GetUnityWrapper();
        public IThreadSafeStreamWrapperLogic<T> GetLogicWrapper();
    }
}