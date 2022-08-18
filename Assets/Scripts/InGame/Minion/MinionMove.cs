using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MinionParamator))]
public class MinionMove : MonoBehaviour
{
    MinionParamator _minionParamator = null;
    int _columCount = 0;
    int _rowCount = 0;

    Cell[,] _cellArray = null;
    bool[,] _isStepArray = null;
    private void Awake()
    {
        _minionParamator = GetComponent<MinionParamator>();
        _columCount = GameManager.Instance.CellManagerInstans.Colm;
        _rowCount = GameManager.Instance.CellManagerInstans.Row;

        //îzóÒèâä˙âª
        _cellArray = GameManager.Instance.CellManagerInstans.CellArray;
        _isStepArray = new bool[_columCount, _rowCount];
    }

    float _timer = 0f;
    public void OnUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= _minionParamator.MoveTime)
        {
            _timer = 0f;
            CheckAround(_minionParamator.CurrentPos.Value.x, _minionParamator.CurrentPos.Value.y);         
        }
    }

    void CheckAround(int colom, int row)
    {    
        bool isLeft = row == 0;
        bool isRight = row == _rowCount - 1;
        bool isTop = colom == 0;
        bool isBottom = colom == _columCount - 1;

        if (!isLeft)//ç∂
        {
            if ((_cellArray[colom, row - 1].CurrentCellType == CellTypes.Load || _cellArray[colom, row - 1].CurrentCellType == CellTypes.HeroArea) && !_isStepArray[colom, row - 1])
            {
                _isStepArray[colom, row - 1] = true;
                Move(colom, row - 1);
                _cellArray[colom, row].MinionOnCell = null;
                return;
            }
        }
        if (!isRight)
        {
            if ((_cellArray[colom, row + 1].CurrentCellType == CellTypes.Load || _cellArray[colom, row + 1].CurrentCellType == CellTypes.HeroArea) && !_isStepArray[colom, row + 1])
            {
                _isStepArray[colom, row + 1] = true;
                Move(colom, row + 1);
                _cellArray[colom, row].MinionOnCell = null;
                return;
            }
        }
        if (!isTop)
        {
            if ((_cellArray[colom - 1, row].CurrentCellType == CellTypes.Load || _cellArray[colom - 1, row].CurrentCellType == CellTypes.HeroArea) && !_isStepArray[colom - 1, row])
            {
                _isStepArray[colom - 1, row] = true;
                Move(colom - 1, row);
                _cellArray[colom, row].MinionOnCell = null;

                return;
            }
        }
        if (!isBottom)
        {
            if ((_cellArray[colom + 1, row].CurrentCellType == CellTypes.Load || _cellArray[colom + 1, row].CurrentCellType == CellTypes.HeroArea) && !_isStepArray[colom + 1, row])
            {
                _isStepArray[colom + 1, row] = true;
                Move(colom + 1, row);
                _cellArray[colom, row].MinionOnCell = null;

                return;
            }
        }
    }

    void Move(int colom, int row)
    {
        this.transform.SetParent(_cellArray[colom, row].transform);
        _minionParamator.CurrentPos = new Vector2Int(colom, row);
        _cellArray[colom, row].MinionOnCell = _minionParamator;
    }
}
