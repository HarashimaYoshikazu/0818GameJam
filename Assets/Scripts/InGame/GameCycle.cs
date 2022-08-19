using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
    //ÉQÅ[ÉÄÇÃèÛë‘ä«óù
    enum GameStateEvent
    {
        Start,
        Pause,
        End
    }

    StateMachine<GameStateEvent> _gameState = new StateMachine<GameStateEvent>();
    private void Awake()
    {
        //ëJà⁄ÇÃê›íË
        _gameState.AddTransition<StartState, IngameState>(GameStateEvent.Start);
        _gameState.AddTransition<IngameState,EndState >(GameStateEvent.End);
        _gameState.StartSetUp<StartState>();
    }
    private void Update()
    {
        _gameState.Update();
    }

    public void StartEvent()
    {
        _gameState.Dispatch(GameStateEvent.Start);
    }

    class StartState : StateMachine<GameStateEvent>.State
    {


        public override void OnUpdate()
        {
            
        }

        protected override void OnExit(StateMachine<GameStateEvent>.State nextState)
        {
            
        }
    }
    class IngameState : StateMachine<GameStateEvent>.State
    {
        public override void OnEnter(StateMachine<GameStateEvent>.State prevState)
        {
            UIManager.Instance.CreateVillanViewPanel();
            GameManager.Instance.HeroGeneretorInstance.OnStart();
        }

        public override void OnUpdate()
        {
            GameManager.Instance.HeroGeneretorInstance.OnUpdate();
            UIManager.Instance.OnUpdate();
        }
    }

    class EndState : StateMachine<GameStateEvent>.State
    {

    }

    class PauseState : StateMachine<GameStateEvent>.State
    {

    }


}