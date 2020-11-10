using System;
using Hara.Abstractions;

namespace Hara.Server.Services
{
    public class CounterState : ICounterState
    {
        public int CurrentCount { get; private set; }

        public void IncrementCount()
        {
            CurrentCount++;
            StateChanged?.Invoke();
        }

        public event Action StateChanged;
    }
}
