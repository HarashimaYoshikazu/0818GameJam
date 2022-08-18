using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MinionParamator))]
public class MinionAttack : MonoBehaviour
{
    MinionParamator _minionParamator = null;
    int _columCount = 0;
    int _rowCount = 0;

    float _timer = 0f;

    Cell[,] _cellArray = null;
    private void Awake()
    {
        _minionParamator = GetComponent<MinionParamator>();
        _columCount = GameManager.Instance.CellManagerInstans.Colm;
        _rowCount = GameManager.Instance.CellManagerInstans.Row;
        //îzóÒèâä˙âª
        _cellArray = GameManager.Instance.CellManagerInstans.CellArray;
    }

    private void Update()
    {
        if (_timer > _minionParamator.Interval)
        {
            CheckAround(_minionParamator.CurrentPos.Value.x, _minionParamator.CurrentPos.Value.y);
        }
    }
    public void Attack(MinionParamator minion)
    {
        minion.HP -= _minionParamator.Atk;
        _timer = 0f;
    }

    void CheckAround(int colom, int row)
    {
        bool isLeft = row == 0;
        bool isRight = row == _rowCount - 1;
        bool isTop = colom == 0;
        bool isBottom = colom == _columCount - 1;

        if (!isLeft)//ç∂
        {
            if (_cellArray[colom, row - 1].CurrentCellType == CellTypes.AlreadyHero)
            {
                Attack(_cellArray[colom, row - 1].HeroOnCell);
                return;
            }
        }
        if (!isRight)
        {
            if (_cellArray[colom, row + 1].CurrentCellType == CellTypes.AlreadyHero)
            {
                Attack(_cellArray[colom, row + 1].HeroOnCell);
                return;
            }
        }
        if (!isTop)
        {
            if (_cellArray[colom - 1, row].CurrentCellType == CellTypes.AlreadyHero)
            {
                Attack(_cellArray[colom - 1, row].HeroOnCell);
                return;
            }
        }
        if (!isBottom)
        {
            if (_cellArray[colom + 1, row].CurrentCellType == CellTypes.AlreadyHero)
            {
                Attack(_cellArray[colom + 1, row].HeroOnCell);
                return;
            }
        }
    }
}
