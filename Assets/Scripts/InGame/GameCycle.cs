using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
    //ゲームの状態管理
    enum GameStateEvent
    {
        GoBattle,
        GoHome,
    }

    StateMachine<GameStateEvent> _gameState = new StateMachine<GameStateEvent>();
    private void Awake()
    {
        //遷移の設定
        //_gameState.AddTransition<TitleScene, HomeScene>(GameStateEvent.GoHome);

        _gameState.StartSetUp<Start>();
    }

    class Start : StateMachine<GameStateEvent>.State
    {

    }
    class Ingame : StateMachine<GameStateEvent>.State
    {

    }
}