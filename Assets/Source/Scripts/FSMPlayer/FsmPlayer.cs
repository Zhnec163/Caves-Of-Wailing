using System;
using System.Collections.Generic;

public class FsmPlayer
{
    private readonly Dictionary<Type, FsmPlayerState> _states = new();
    
    private FsmPlayerState _currentState;

    public void AddState(FsmPlayerState fsmPlayerState) =>
        _states.Add(fsmPlayerState.GetType(), fsmPlayerState);

    public void SetState<T>() where T : FsmPlayerState
    {
        var type = typeof(T);

        if (_currentState != null && _currentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }

    public void Update() =>
        _currentState?.Update();
}
