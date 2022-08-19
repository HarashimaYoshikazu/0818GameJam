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
        Clear,
        GameOver
    }

    StateMachine<GameStateEvent> _gameState = new StateMachine<GameStateEvent>();
    private void Awake()
    {
        //ëJà⁄ÇÃê›íË
        _gameState.AddTransition<StartState, IngameState>(GameStateEvent.Start);
        _gameState.AddTransition<IngameState,ClearState >(GameStateEvent.Clear);
        _gameState.AddTransition<IngameState, GameOverState>(GameStateEvent.GameOver);
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
    public void ClearEvent()
    {
        _gameState.Dispatch(GameStateEvent.Clear);
    }
    public void GameOverEvent()
    {
        _gameState.Dispatch(GameStateEvent.GameOver);
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
        [SerializeField]
        float _timeLimit = 40f;
        float _timer = 0f;
        public override void OnEnter(StateMachine<GameStateEvent>.State prevState)
        {
            _timer = _timeLimit;
            UIManager.Instance.CreateUIObject();
            GameManager.Instance.HeroGeneretorInstance.OnStart();
        }

        public override void OnUpdate()
        {
            _timer -= Time.deltaTime;
            UIManager.Instance.ChangeTimeText((int)_timer);
            if (_timer <= 0f)
            {
                GameManager.Instance.GameCycleInstans.GameOverEvent();
            }
            GameManager.Instance.HeroGeneretorInstance.OnUpdate();
            UIManager.Instance.OnUpdate();
        }
    }

    class ClearState : StateMachine<GameStateEvent>.State
    {
        public override void OnEnter(StateMachine<GameStateEvent>.State prevState)
        {
            GameObject go = Resources.Load<GameObject>("UIPrefabs/ClearCanvas");
            GameObject.Instantiate(go);
            GameManager.Instance.SoundManager.ClipPlay(Resources.Load<AudioClip>("result/clear"));
        }
    }
    class GameOverState : StateMachine<GameStateEvent>.State
    {
        public override void OnEnter(StateMachine<GameStateEvent>.State prevState)
        {
            GameObject go = Resources.Load<GameObject>("UIPrefabs/GameOverCanvas");
            GameObject.Instantiate(go);
            GameManager.Instance.SoundManager.ClipPlay(Resources.Load<AudioClip>("result/gameover"));
        }
    }

    class PauseState : StateMachine<GameStateEvent>.State
    {

    }


}