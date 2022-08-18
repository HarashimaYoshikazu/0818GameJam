using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// パラメータを格納するクラス
/// </summary>
public class MinionParamator : MonoBehaviour
{
    Vector2Int? _startPos = null;
    public Vector2Int? StartPos
    {
        get { return _startPos; }
        set
        {
            _startPos = value;
            _currentPos = value;
        }
    }

    Vector2Int? _currentPos = null;
    public Vector2Int? CurrentPos
    {
        get
        {
            if (_currentPos == null && this.transform.parent.TryGetComponent<Cell>(out Cell cell))
            {
                if (cell.CellPos == null)
                {
                    throw new System.ArgumentNullException("生成時に座標が正しくセットされていないか、オブジェクトの名称が不正です。");
                }
                _currentPos = cell.CellPos;
            }
            return _currentPos;
        }
        set { _currentPos = value; }
    }

    [SerializeField]
    int _atk = 0;
    public int Atk
    {
        get { return _atk; }
        set { _atk = Mathf.Clamp(_atk + value, 0, _atk + value); }
    }

    [SerializeField]
    int _hP = 0;
    public int HP
    {
        get { return _hP; }
        set
        {
            _hP = Mathf.Clamp(_hP + value, 0, _hP + value);
            if (_hP <= 0)
            {
                Death();
            }
        }
    }

    [SerializeField]
    float _moveTime = 0f;
    public float MoveTime
    {
        get { return _moveTime; }
        set { _moveTime = Mathf.Clamp(_moveTime + value, 0, _moveTime + value); }
    }

    [SerializeField]
    float _interval = 0f;
    public float Interval
    {
        get { return _interval; }
        set { _interval = Mathf.Clamp(_interval + value, 0, _interval + value); }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
