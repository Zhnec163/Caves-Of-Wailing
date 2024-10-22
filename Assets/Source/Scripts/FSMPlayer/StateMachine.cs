using System;
using System.Collections.Generic;
using Scripts.FSMPlayer.States;

namespace Scripts.FSMPlayer
{
    public class StateMachine
    {
        private readonly Dictionary<Type, BaseState> _states = new();

        private BaseState _currentState;

        public void AddState(BaseState baseState) =>
            _states.Add(baseState.GetType(), baseState);

        public void SetState<T>() where T : BaseState
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

        public void FixedUpdate() =>
            _currentState?.FixedUpdate();
    }
}