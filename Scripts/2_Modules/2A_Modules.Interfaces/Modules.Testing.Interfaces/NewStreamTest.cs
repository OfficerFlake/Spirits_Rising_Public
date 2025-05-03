using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OldStreamTest
{
    public interface IGameEntity
    {
        public Enum EnumType { get; }
    }
    public interface IConsole
    {
        IMonoDirectionalStreamWrapper<string> Messages { get; set; }
        IMonoDirectionalStreamWrapper<bool> Show { get; set; }
    }
    public class TestConsole : IGameEntity, IConsole
    {
        public Enum EnumType { get; }

        public IMonoDirectionalStreamWrapper<string> Messages { get; set; }
        public IMonoDirectionalStreamWrapper<bool> Show { get; set; }

        public TestConsole(StreamWrapperType type)
        {
            Messages = new ThreadSafeStream<string>().GetWrapper(type);
            Show = new ThreadSafeStream<bool>().GetWrapper(type);
        }
    }

    public interface IThreadSafeStream<T>
    {
        public T LogicValue { get; set; }
        public T UnityValue { get; set; }
        public ConcurrentQueue<T> UnityStream { get; }
        public ConcurrentQueue<T> LogicStream { get; }
        public IMonoDirectionalStreamWrapper<T> GetWrapper(StreamWrapperType type);
        public IMonoDirectionalStreamWrapper<T> GetUnityWrapper();
        public IMonoDirectionalStreamWrapper<T> GetLogicWrapper();
    }
    public interface IMonoDirectionalStreamWrapper<T>
    {
        public ConcurrentQueue<T> Stream { get; }
        public T Value { get; set; }
    }
    public enum StreamWrapperType
    {
        Unity,
        Logic
    }
    public class ThreadSafeStream<T>  : IThreadSafeStream<T>
    {
        public T LogicValue { get; set; }
        public T UnityValue { get; set; }
        public ConcurrentQueue<T> UnityStream { get; }
        public ConcurrentQueue<T> LogicStream { get; }
        public ThreadSafeStream()
        {
            UnityStream = new ConcurrentQueue<T>();
            LogicStream = new ConcurrentQueue<T>();
        }

        public IMonoDirectionalStreamWrapper<T> GetWrapper(StreamWrapperType type)
        {
            return type switch
            {
                StreamWrapperType.Unity => GetUnityWrapper(),
                StreamWrapperType.Logic => GetLogicWrapper(),
                _ => throw new NotImplementedException()
            };
        }
        public IMonoDirectionalStreamWrapper<T> GetUnityWrapper()
        {
            return new UnityStream<T>(this);
        }
        public IMonoDirectionalStreamWrapper<T> GetLogicWrapper()
        {
            return new LogicStream<T>(this);
        }
    }
    public class UnityStream<T> : IMonoDirectionalStreamWrapper<T>
    {
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                Stream.Enqueue(value);
            }
        }
        public ConcurrentQueue<T> Stream { get; }
        public ThreadSafeStream<T> Parent { get; }
        public UnityStream(ThreadSafeStream<T> parent)
        {
            Parent = parent;
            Stream = Parent.UnityStream;
        }
    }   
    public class LogicStream<T> : IMonoDirectionalStreamWrapper<T>
    {
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                Stream.Enqueue(value);
            }
        }
        public ConcurrentQueue<T> Stream { get; }
        public ThreadSafeStream<T> Parent { get; }
        public LogicStream(ThreadSafeStream<T> parent)
        {
            Parent = parent;
            Stream = Parent.LogicStream;
        }
    }

}

namespace NewStreamTest
{
    public interface IStreamManager
    {
        private static readonly Dictionary<Enum, object> _streams = new();
        public static IMonoDirectionalStream<T> GetMonoDirectionalStream<T>(Enum key, StreamTypeEnum type)
        {
            var stream = GetBiDirectionalStream<T>(key);
            return type == StreamTypeEnum.Unity ? stream.Unity : stream.Logic;
        }
        public static IBiDirectionalStream<T> GetBiDirectionalStream<T>(Enum key)
        {
            if (!_streams.TryGetValue(key, out var stream))
            {
                stream = new BiDirectionalStream<T>();
                _streams[key] = stream;
            }
            return (IBiDirectionalStream<T>)stream;
        }
    }
    public enum StreamTypeEnum
    {
        Unity,
        Logic
    }


    public interface IMonoDirectionalStream<T>
    {
        BiDirectionalStream<T> Parent { get; }
        ConcurrentQueue<T> Queue { get; }
        T Value { get; set; }
    }
    public class MonoDirectionalStream<T> : IMonoDirectionalStream<T>
    {
        public BiDirectionalStream<T> Parent { get; }
        public ConcurrentQueue<T> Queue { get; }

        private T _value;
        public T Value { get { return _value; } set { Queue.Enqueue(value); _value = value; } }
        public MonoDirectionalStream(BiDirectionalStream<T> stream)
        {
            Parent = stream;
            Queue = new ConcurrentQueue<T>();
        }
    }
    public interface IBiDirectionalStream<T>
    {
        IMonoDirectionalStream<T> Unity { get; }
        IMonoDirectionalStream<T> Logic { get; }
    }
    public class BiDirectionalStream<T> : IBiDirectionalStream<T>
    {
        public IMonoDirectionalStream<T> Unity { get; }
        public IMonoDirectionalStream<T> Logic { get; }

        public BiDirectionalStream()
        {
            Unity = new MonoDirectionalStream<T>(this);
            Logic = new MonoDirectionalStream<T>(this);
        }
    }


    public interface IGameEntity
    {
        public Enum Enum { get; }
    }
    public interface IStreamable
    {
        public StreamTypeEnum Type { get; }
    }


    public interface IConsole
    {
        IMonoDirectionalStream<string> Messages { get; set; }
        IMonoDirectionalStream<bool> Show { get; set; }
    }
    public class ConsoleUnity : IGameEntity, IStreamable, IConsole
    {
        public Enum Enum { get; }
        public StreamTypeEnum Type { get; } = StreamTypeEnum.Unity;

        public IMonoDirectionalStream<string> Messages { get; set; }
        public IMonoDirectionalStream<bool> Show { get; set; }

        public ConsoleUnity()
        {
            Messages = IStreamManager.GetMonoDirectionalStream<string>(Enum, Type);
            Show = IStreamManager.GetMonoDirectionalStream<bool>(Enum, Type);
        }
    }
    public class ConsoleLogic : IGameEntity, IStreamable, IConsole
    {
        public Enum Enum { get; }
        public StreamTypeEnum Type { get; } = StreamTypeEnum.Logic;

        public IMonoDirectionalStream<string> Messages { get; set; }
        public IMonoDirectionalStream<bool> Show { get; set; }

        public ConsoleLogic()
        {
            Messages = IStreamManager.GetMonoDirectionalStream<string>(Enum, Type);
            Show = IStreamManager.GetMonoDirectionalStream<bool>(Enum, Type);
        }
    }
}