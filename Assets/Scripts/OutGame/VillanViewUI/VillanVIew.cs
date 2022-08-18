using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class VillanVIew : MonoBehaviour, IBeginDragHandler, IPointerUpHandler,IDragHandler,IPointerDownHandler
{
    [SerializeField]
    int _id = 1;

    int _atk = 0;
    int _hP = 0;
    float _moveTime = 0f;

    float _coolTime = 0f;
    int _createValue = 0;
    int _levelUpValue = 0;

    GameObject _prefab = null;

    Image _image;

    /// <summary>キャッシュ用の変数</summary>
    GameObject _currentPointerObject = null;

    private void Awake()
    {
        InitData();
    }

    void InitData()
    {
        _image = GetComponent<Image>();
        var data = Resources.Load<VillanData>($"VillanData/Villan{_id}");
        _atk = data.InitAtk;
        _hP = data.InitHP;
        _moveTime = data.InitMoveTime;
        _coolTime = data.InitCoolTime;
        _createValue = data.InitCreateValue;
        _levelUpValue = data.InitLevelUpValue;
        _image.sprite = data.GetSprite;
        _prefab = data.Prefab;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //カードの下のObjectを取得したいからraycastTargetを無効にする
        _image.raycastTarget = false;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentPointerObject = eventData.pointerCurrentRaycast.gameObject;
        this.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(_currentPointerObject);
        if (_currentPointerObject.TryGetComponent<Cell>(out Cell cell))
        {
            if (cell.CurrentCellType ==CellType.SpawonPoint)
            {
                //生成
                Instantiate(_prefab,_currentPointerObject.transform);
            }
        }
        _image.raycastTarget = true;
        this.transform.SetParent(UIManager.Instance.UIVillanSelectPanel.transform);              
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
