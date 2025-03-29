using System.Collections.Generic;

namespace Common.ThreadSafeStream.Interfaces
{
    public interface IThreadSafeStreamWrapperDown<T>
    {
        public List<T> Value { get; set; }
        public static IThreadSafeStreamWrapperDown<T> operator +(IThreadSafeStreamWrapperDown<T> streamWrapper, T value)
        {
            streamWrapper.Value?.Add(value);
            return streamWrapper;
        }

        public static IThreadSafeStreamWrapperDown<T> operator -(IThreadSafeStreamWrapperDown<T> streamWrapper, T value)
        {
            streamWrapper.Value?.RemoveAll((x) => EqualityComparer<T>.Default.Equals(x, value));
            return streamWrapper;
        }
    }
}