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

    int _initAtk = 0;
    int _initHP = 0;
    float _initMoveTime = 0f;

    float _coolTime = 0f;
    int _createValue = 0;
    int _levelUpValue = 0;

    MinionParamator _prefab = null;

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
        _initAtk = data.InitAtk;
        _initHP = data.InitHP;
        _initMoveTime = data.InitMoveTime;
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
        if (_currentPointerObject.TryGetComponent<Cell>(out Cell cell))
        {
            if (cell.CurrentCellType ==CellTypes.SpawonPoint)
            {
                //生成
                var minion = Instantiate(_prefab,_currentPointerObject.transform);
                minion.HP = _initHP;
                minion.Atk = _initAtk;
                minion.MoveTime = _initMoveTime;
                minion.StartPos = cell.CellPos;
            }
        }
        _image.raycastTarget = true;
        this.transform.SetParent(UIManager.Instance.UIVillanSelectPanel.transform);              
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
