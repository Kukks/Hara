using System;

namespace Hara.Abstractions
{
    public interface ICounterState
    {
        int CurrentCount { get; }
        void IncrementCount();
        event Action StateChanged;
    }
}