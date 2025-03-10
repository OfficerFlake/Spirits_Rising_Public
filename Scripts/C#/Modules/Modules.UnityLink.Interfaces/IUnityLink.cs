using System;
using System.Threading;

namespace Modules.UnityLink.Interfaces
{
    public interface IUnityLink<T>
    {
        ConnectionData Connection { get; set; }

        public class ConnectionData
        {
            private ReaderWriterLockSlim _UpLock = new ReaderWriterLockSlim();
            private ReaderWriterLockSlim _DownLock = new ReaderWriterLockSlim();

            private T _up;
            public T Up
            {
                get
                {
                    _UpLock.EnterReadLock();
                    try
                    {
                        return _up;
                    }
                    finally
                    {
                        _UpLock.ExitReadLock();
                    }
                } 
                set
                {

                    System.Diagnostics.Debug.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Attempting to Enter Write Lock for Up");
                    System.Diagnostics.Debug.WriteLine($"UpLock: {_UpLock.GetHashCode()}");
                    _UpLock.EnterWriteLock();
                    try
                    {
                        System.Diagnostics.Debug.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Write Lock Acquired for Up");
                        System.Diagnostics.Debug.WriteLine($"UpLock: {_UpLock.GetHashCode()}");
                        _up = value;
                    }
                    finally
                    {
                        System.Diagnostics.Debug.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Write Lock Try Release for Up");
                        System.Diagnostics.Debug.WriteLine($"UpLock: {_UpLock.GetHashCode()}");
                        _UpLock.ExitWriteLock();
                        System.Diagnostics.Debug.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Write Lock Released for Up");
                        System.Diagnostics.Debug.WriteLine($"UpLock: {_UpLock.GetHashCode()}");
                    }
                }
            }
            private T _down;
            public T Down
            {
                get
                {
                    _DownLock.EnterReadLock();
                    try
                    {
                        return _down;
                    }
                    finally
                    {
                        _DownLock.ExitReadLock();
                    }
                }
                set
                {
                    _DownLock.EnterWriteLock();
                    try
                    {
                        _down = value;
                    }
                    finally
                    {
                        _DownLock.ExitWriteLock();
                    }
                }
            }
            public ConnectionData(T up, T down)
            {
                Up = up;
                Down = down;
            }
        }
    }

    public static class  UnityLinkExtensions
    {
        public static T Get<T>(this IUnityLink<T> unityLink, string direction)
        {
            return direction switch
            {
                "Up" => unityLink.Connection.Up,
                "Down" => unityLink.Connection.Down,
                _ => throw new ArgumentException("Invalid direction"),
            };
        }
    }
}