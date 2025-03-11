using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Modules.ThreadSafeLink.Interfaces
{
    public interface IThreadSafeLink
    {
        public object Up
        {
            get;
            set;
        }
        public object Down
        {
            get;
            set;
        }
    }

    public sealed class ThreadSafeLinkManager
    {
        private static ThreadSafeLinkManager _instance = new ThreadSafeLinkManager();
        public static ThreadSafeLinkManager Instance => _instance;

        private ThreadSafeLinkManager() { }

        public static IThreadSafeLink GetByName(ThreadSafeLinks _enumerator)
        {
            return _links.ContainsKey(_enumerator) ? _links[_enumerator] : null;
        }

        public static void SetByName(ThreadSafeLinks _enumerator, IThreadSafeLink _link)
        {
            _links[_enumerator] = _link;
        }

        private static readonly Dictionary<ThreadSafeLinks, IThreadSafeLink> _links = new Dictionary<ThreadSafeLinks, IThreadSafeLink>();

    }

    public static class ThreadSafeLinkExtensions
    {
        public static object Get(this IThreadSafeLink theadSafeLink, string direction)
        {
            return direction switch
            {
                "Up" => theadSafeLink.Up,
                "Down" => theadSafeLink.Down,
                _ => throw new ArgumentException("Invalid direction"),
            };
        }
    }
}