using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour
{
    [SerializeField]
    CellType _cellType = CellType.Load;
    public CellType CurrentCellType => _cellType;

    Image _image = null;

    private void OnValidate()
    {
        if (!_image)
        {
            _image = GetComponent<Image>(); 
        }
        switch (_cellType)
        {
            case CellType.Load:
                _image.color = Color.white;
                break;
            case CellType.SpawonPoint:
                _image.color = Color.red;
                break;
            case CellType.Block:
                _image.color = Color.black;
                break;
            case CellType.HeroArea:
                _image.color = Color.gray;
                break;
        }

    }
}

public enum CellType
{
    Load,
    SpawonPoint,
    Block,
    HeroArea
}

