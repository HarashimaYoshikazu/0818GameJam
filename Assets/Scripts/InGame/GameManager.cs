using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameManager : Singleton<GameManager>
{
    CellManager _cellManager = null;
    public CellManager CellManagerInstans
    {
        get
        {
            if (!_cellManager)
            {
                _cellManager = GameObject.FindObjectOfType<CellManager>();
                if (!_cellManager)
                {
                    CellManager go = Resources.Load<CellManager>("UIPrefabs/CellCanvas");
                    _cellManager = GameObject.Instantiate(go);
                }
            }
            return _cellManager;
        }
    }

    GameCycle _gameCycle = null;
    public GameCycle GameCycleInstans
    {
        get
        {
            if (!_gameCycle)
            {
                _gameCycle = GameObject.FindObjectOfType<GameCycle>();
                if (!_gameCycle)
                {
                    _gameCycle = new GameObject("GameCycle").AddComponent<GameCycle>();
                }
            }
            return _gameCycle;
        }
    }

    HeroGeneretor _heroGeneretor = null;
    public HeroGeneretor HeroGeneretorInstance
    {
        get
        {
            if (!_heroGeneretor)
            {
                _heroGeneretor = GameObject.FindObjectOfType<HeroGeneretor>();
                if (!_heroGeneretor)
                {
                    _heroGeneretor = new GameObject("HeroGeneretor").AddComponent<HeroGeneretor>();
                }
            }
            return _heroGeneretor;
        }
    }

    int _money = 100;
    public int Money => _money;
    public void ChangeMoney(int value)
    {
        _money += value;
        UIManager.Instance.ChangeMoneyView(_money);
    }

    SoundManager _soundManager = null;
    public SoundManager SoundManager
    {
        get
        {
            if (!_soundManager)
            {
                _soundManager = GameObject.FindObjectOfType<SoundManager>();
                if (!_soundManager)
                {
                    _soundManager = new GameObject("SoundManager").AddComponent<SoundManager>();
                }
            }
            return _soundManager;
        }

    }
}
