using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MinionParamator))]
public class MinionAttack : MonoBehaviour
{
    [SerializeField]
    AudioClip _clip;
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
        //zñú»
        _cellArray = GameManager.Instance.CellManagerInstans.CellArray;
    }

    public void OnUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer > _minionParamator.Interval)
        {
            CheckAround(_minionParamator.CurrentPos.Value.x, _minionParamator.CurrentPos.Value.y);
        }
    }
    public void Attack(MinionParamator minion)
    {
        GameManager.Instance.SoundManager.ClipPlay(_clip);
        minion.Damage(_minionParamator.Atk);
        Debug.Log($"{this.gameObject.name}ÌU{_minionParamator.Atk}");
        _timer = 0f;
        Debug.Log($"{this.gameObject.name}ÌU.{minion.name}É½BcèHP{minion.HP}");
    }

    void CheckAround(int colom, int row)
    {
        CellTypes cellTypes = CellTypes.AlreadyHero;
        switch (_minionParamator.MinionType)
        {
            case MinionType.Hero:
                cellTypes = CellTypes.Load;
                break;
            case MinionType.Villan:
                cellTypes = CellTypes.AlreadyHero;
                break;
        }

        bool isLeft = row == 0;
        bool isRight = row == _rowCount - 1;
        bool isTop = colom == 0;
        bool isBottom = colom == _columCount - 1;

        if (!isLeft)//¶
        {
            if (_cellArray[colom, row - 1].CurrentCellType == cellTypes || _cellArray[colom, row - 1].CurrentCellType ==CellTypes.Boss)
            {
                if (_cellArray[colom, row - 1].MinionOnCell)
                {
                    Attack(_cellArray[colom, row - 1].MinionOnCell);
                    return;
                }


            }
        }
        if (!isRight)
        {
            if (_cellArray[colom, row + 1].CurrentCellType == cellTypes|| _cellArray[colom, row + 1].CurrentCellType == CellTypes.Boss)
            {
                if (_cellArray[colom, row + 1].MinionOnCell)
                {
                    Attack(_cellArray[colom, row + 1].MinionOnCell);
                    return;
                }


            }
        }
        if (!isTop)
        {
            if (_cellArray[colom - 1, row].CurrentCellType == cellTypes|| _cellArray[colom - 1, row].CurrentCellType == CellTypes.Boss)
            {
                if (_cellArray[colom - 1, row].MinionOnCell)
                {
                    Attack(_cellArray[colom - 1, row].MinionOnCell);
                    return;
                }

            }
        }
        if (!isBottom)
        {
            if (_cellArray[colom + 1, row].CurrentCellType == cellTypes|| _cellArray[colom + 1, row].CurrentCellType == CellTypes.Boss)
            {
                if (_cellArray[colom + 1, row].MinionOnCell)
                {
                    Attack(_cellArray[colom + 1, row].MinionOnCell);
                    return;
                }

            }
        }
    }
}
