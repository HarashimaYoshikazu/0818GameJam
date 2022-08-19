using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
    //�Q�[���̏�ԊǗ�
    enum GameStateEvent
    {
        Start,
        Pause,
        End
    }

    StateMachine<GameStateEvent> _gameState = new StateMachine<GameStateEvent>();
    private void Awake()
    {
        //�J�ڂ̐ݒ�
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
    public void EndEvent()
    {
        _gameState.Dispatch(GameStateEvent.End);
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
            UIManager.Instance.CreateUIObject();
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
        public override void OnEnter(StateMachine<GameStateEvent>.State prevState)
        {
            GameObject go = Resources.Load<GameObject>("UIPrefabs/ResultCanvas");
            GameObject.Instantiate(go);
        }
    }

    class PauseState : StateMachine<GameStateEvent>.State
    {

    }


}