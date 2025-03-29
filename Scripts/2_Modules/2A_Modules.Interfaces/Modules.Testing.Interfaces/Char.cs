using Common.ThreadSafeStream.Implementation;
using Common.ThreadSafeStream.Interfaces;
using System;
using UnityEngine;

namespace NewLinkingSystem
{
    public enum Characters
    {
        Tim
    }
    public interface ICharTest
    {
        Characters CharEnum { get; set; }
        IThreadSafeStream<int> Test { get; set; }
        IThreadSafeStream<string> Test2 { get; set; }
    }

    public abstract class OnEventListener
    {
        private readonly Action _onTick = null;
        public OnEventListener(Action _onTickDelegate)
        {
            _onTick = _onTickDelegate;
            //GameLoop.TickEvent += _onTick;
            throw new NotImplementedException("");
        }
        ~OnEventListener()
        {
            //GameLoop.TickEvent -= _onTickDelegate;
            throw new NotImplementedException();
        }
        public void OnTick() => _onTick.Invoke();
    }
    public class OnTickEventListener : OnEventListener
    {
        public OnTickEventListener(Action _onTickDelegate) : base(_onTickDelegate) { }
    }

    public class ICharTestLogic
    {
        OnTickEventListener OnTickEventListener { get; set; }
        Characters CharEnum { get; set; }
        IThreadSafeStreamWrapperDown<int> Test { get; set; }
        IThreadSafeStreamWrapperDown<string> Test2 { get; set; }

        public ICharTestLogic()
        {
            //Link Pos
            Test = (IThreadSafeStreamWrapperDown<int>)new ThreadSafeStreamWrapperDown<int>(new ThreadSafeStream<int>(0, 0));
            //Link Rot
            Test2 = (IThreadSafeStreamWrapperDown<string>)new ThreadSafeStreamWrapperDown<string>(new ThreadSafeStream<string>("Up", "Down"));

            //Confirm operations working
            Test += 1;
            Test2 += "Hello";

            //Link OnTick()
            OnTickEventListener = new OnTickEventListener(() => OnTick());
        }
        public void OnTick()
        {
            throw new NotImplementedException();
            //Read from Up.
            //Read from Value
            //Write to Down.

            //Never clear Value; It holds the actual state of the logic object!
        }
    }
    public class ICharTestUnity : MonoBehaviour
    {
        Characters CharacterID { get; set; }
        IThreadSafeStreamWrapperUp<int> Test { get; set; }
        IThreadSafeStreamWrapperUp<string> Test2 { get; set; }

        public void Start()
        {
            Test = (IThreadSafeStreamWrapperUp<int>)new ThreadSafeStreamWrapperUp<int>(new ThreadSafeStream<int>(0, 0));
            Test2 = (IThreadSafeStreamWrapperUp<string>)new ThreadSafeStreamWrapperUp<string>(new ThreadSafeStream<string>("Up", "Down"));
            //Confirm operations working
            Test += 1;
            Test2 += "Hello";   
        }
        public void Update()
        {
            throw new NotImplementedException();
            //Read from Down.
            //Read from Value
            //Write to Up.

            //Never clear Value; It holds the actual state of the unity object!
        }
    }
}