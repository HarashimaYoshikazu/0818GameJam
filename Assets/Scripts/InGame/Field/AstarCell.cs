using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarCell
{
    [SerializeField]
    AstarCellTypes _cellType;
    public AstarCellTypes CurrentCellType => _cellType;

    [Header("�X�e�[�^�X")]
    [Tooltip("����X�R�A")]
    int _estimationScore = 0;
    public int EstimationScore
    {
        get => _estimationScore;
        set => _estimationScore = value;
    }
    [Tooltip("���X�R�A")]
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
    [Tooltip("�ŏI�X�R�A")]
    int _resultScore = 0;
    public int ResultScore
    {
        get => _resultScore;
    }
    [Tooltip("�I�[�v����")]
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
