using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarCell
{
    [SerializeField]
    AstarCellTypes _cellType;
    public AstarCellTypes CurrentCellType => _cellType;

    [Header("ステータス")]
    [Tooltip("推定スコア")]
    int _estimationScore = 0;
    public int EstimationScore
    {
        get => _estimationScore;
        set => _estimationScore = value;
    }
    [Tooltip("実スコア")]
    int _actualScore = 0;
    public int ActualScore
    {
        get => _actualScore;
        set
        {
            _actualScore = value;
            _resultScore = _actualScore + _estimationScore;
            IsCheck = true;
        }
    }
    [Tooltip("最終スコア")]
    int _resultScore = 0;
    public int ResultScore
    {
        get => _resultScore;
    }
    [Tooltip("オープン元")]
    Vector2Int _openSourceIndex = new Vector2Int(-1, -1);
    public Vector2Int OpenSourceIndex
    {
        get => _openSourceIndex;
        set => _openSourceIndex = value;
    }

    public bool IsCheck = false;
    public bool IsStartCel = false;


    public void SetType(AstarCellTypes type)
    {
        _cellType = type;
    }
}
public enum AstarCellTypes
{
    Start,
    Goal,
    Empty,
    Wall,
    Open,
    Close
}
