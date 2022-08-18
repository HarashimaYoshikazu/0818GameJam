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
    public CellTypes CurrentCellType => _cellType;

    Image _image = null;

    MinionParamator _heroOnCell = null;
    public MinionParamator HeroOnCell
    {
        get => _heroOnCell;
        set => _heroOnCell = value;
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

    private void OnValidate()
    {
        if (!_image)
        {
            _image = GetComponent<Image>();
        }
        switch (_cellType)
        {
            case CellTypes.Load:
                _image.color = Color.white;
                break;
            case CellTypes.SpawonPoint:
                _image.color = Color.red;
                break;
            case CellTypes.Block:
                _image.color = Color.black;
                break;
            case CellTypes.HeroArea:
                _image.color = Color.gray;
                break;
            case CellTypes.AlreadyHero:
                _image.color = Color.green;
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
    AlreadyHero
}

