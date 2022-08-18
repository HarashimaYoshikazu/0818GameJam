using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
    //�Q�[���̏�ԊǗ�
    enum GameStateEvent
    {
        GoBattle,
        GoHome,
    }

    StateMachine<GameStateEvent> _gameState = new StateMachine<GameStateEvent>();
    private void Awake()
    {
        //�J�ڂ̐ݒ�
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