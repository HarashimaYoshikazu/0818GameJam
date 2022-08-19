using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour
{
    [SerializeField]
    CellTypes _cellType = CellTypes.Load;
    public CellTypes CurrentCellType
    {
        get { return _cellType; }
        set { _cellType = value; }
    }

    Image _image = null;

    MinionParamator _heroOnCell = null;
    public MinionParamator MinionOnCell
    {
        get
        {
            return _heroOnCell;
        }
        set { _heroOnCell = value; }
    }

    Vector2Int? _cellPos = null;
    public Vector2Int? CellPos
    {
        get
        {
            if (_cellPos == null)
            {
                var line = this.gameObject.name.Split(' ');
                _cellPos = new Vector2Int(int.Parse(line[0]), int.Parse(line[1]));
            }
            Debug.Log(_cellPos);
            return _cellPos;
        }
        set { _cellPos = value; }
    }

    Sprite _bush = null;
    Sprite _dart = null;
    Sprite _spawnPoint = null;
    Sprite _wall = null;
    private void OnValidate()
    {
        if (!_image)
        {
            _image = GetComponent<Image>();
        }
        if (!_bush)
        {
            _bush = Resources.Load<Sprite>("Cells/bush");
            _dart = Resources.Load<Sprite>("Cells/dart");
            _spawnPoint = Resources.Load<Sprite>("Cells/Spawn1");
            _wall = Resources.Load<Sprite>("Cells/wall");
        }

        switch (_cellType)
        {
            case CellTypes.Load:
                _image.sprite = _bush;
                break;
            case CellTypes.SpawonPoint:
                _image.sprite = _spawnPoint;
                break;
            case CellTypes.Block:
                _image.sprite = _wall;
                break;
            case CellTypes.HeroArea:
                _image.sprite = _dart;
                break;
            case CellTypes.AlreadyHero:
                //_image.sprite
                break;
            case CellTypes.Boss:
                _image.sprite= _dart;
                _image.color = Color.black;
                break;
        }

    }
}

public enum CellTypes
{
    Load,
    SpawonPoint,
    Block,
    HeroArea,
    AlreadyHero,
    Boss
}

