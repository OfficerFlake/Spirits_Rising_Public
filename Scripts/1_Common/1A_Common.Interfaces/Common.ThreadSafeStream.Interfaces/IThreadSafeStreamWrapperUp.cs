using System.Collections.Generic; 

namespace Common.ThreadSafeStream.Interfaces
{
    public interface IThreadSafeStreamWrapperUp<T>
    {
        public List<T> Value { get; set; }
        public static IThreadSafeStreamWrapperUp<T> operator +(IThreadSafeStreamWrapperUp<T> streamWrapper, T value)
        {
            streamWrapper.Value?.Add(value);
            return streamWrapper;
        }

        public static IThreadSafeStreamWrapperUp<T> operator -(IThreadSafeStreamWrapperUp<T> streamWrapper, T value)
        {
            streamWrapper.Value?.RemoveAll((x) => EqualityComparer<T>.Default.Equals(x, value));
            return streamWrapper;
        }
    }
}