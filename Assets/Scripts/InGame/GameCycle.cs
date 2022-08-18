using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
    //ƒQ[ƒ€‚Ìó‘ÔŠÇ—
    enum GameStateEvent
    {
        Start,
        Pause,
        End
    }

    StateMachine<GameStateEvent> _gameState = new StateMachine<GameStateEvent>();
    private void Awake()
    {
        //‘JˆÚ‚Ìİ’è
        _gameState.AddTransition<StartState, IngameState>(GameStateEvent.Start);
        _gameState.AddTransition<IngameState,EndState >(GameStateEvent.Start);
        _gameState.StartSetUp<StartState>();
    }

    class StartState : StateMachine<GameStateEvent>.State
    {
        public override void OnEnter(StateMachine<GameStateEvent>.State prevState)
        {
            
        }

        protected override void OnUpdate()
        {
            
        }

        protected override void OnExit(StateMachine<GameStateEvent>.State nextState)
        {
            
        }
    }
    class IngameState : StateMachine<GameStateEvent>.State
    {

    }

    class EndState : StateMachine<GameStateEvent>.State
    {

    }

    class PauseState : StateMachine<GameStateEvent>.State
    {

    }


}