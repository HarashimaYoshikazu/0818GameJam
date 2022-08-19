using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class VillanVIew : MonoBehaviour, IBeginDragHandler, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    int _id = 1;
    [SerializeField]
    Button _button;
    GameObject _panelOnButton = null;
    public int ID => _id;

    int _initAtk = 0;
    int _initHP = 0;
    float _initMoveTime = 0f;
    float _interval = 0f;

    float _coolTime = 0f;
    int _createValue = 0;
    int _levelUpValue = 0;

    const int _atkLevelUpValue = 3;
    const int _hpLevelUpValue = 3;
    const float _moveTimeLevelUpTime = 0.3f;
    const float _coolTimeLevelUpTime = 0.2f;
    const float _intervalLevelUpTime = 0.2f;

    MinionParamator _prefab = null;

    Image _image;

    /// <summary>キャッシュ用の変数</summary>
    GameObject _currentPointerObject = null;

    List<GameObject> _villanList = new List<GameObject>();
    public void RemoveVillan(GameObject minion)
    {
        _villanList.Remove(minion);
    }
    private void Awake()
    {
        InitData();
    }

    float _timer = 0f;
    public void OnUpdate()
    {
        foreach (var mini in _villanList)
        {
            if (mini.TryGetComponent<MinionMove>(out MinionMove move))
            {
                move.OnUpdate();
            }
            if (mini.TryGetComponent<MinionAttack>(out MinionAttack attack))
            {
                attack.OnUpdate();
            }
        }
        _timer += Time.deltaTime;
        if (_coolTime > _timer)
        {
            _image.color = Color.gray;
        }
        else
        {
            _image.color = Color.white;
        }

        if (_levelUpValue > GameManager.Instance.Money)
        {
            _panelOnButton.SetActive(true);
        }
        else
        {
            _panelOnButton.SetActive(false);
        }
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
        _interval = data.Interval;
        _prefab = data.Prefab;

        _button.onClick.AddListener(() => { LevelUp(); });
        _panelOnButton = Instantiate(Resources.Load<GameObject>("UIPrefabs/PanelOnButton"), _button.transform);
    }

    public void LevelUp()
    {
        if (_levelUpValue < GameManager.Instance.Money)
        {
            GameManager.Instance.ChangeMoney(-(_levelUpValue));
            _initAtk += _atkLevelUpValue;
            _initHP += _hpLevelUpValue;
            _initMoveTime -= _moveTimeLevelUpTime;
            _interval -= _intervalLevelUpTime;
            _coolTime -= _coolTimeLevelUpTime;
            _createValue++;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_coolTime > _timer)
        {
            return;
        }
        //カードの下のObjectを取得したいからraycastTargetを無効にする
        _image.raycastTarget = false;
        _button.gameObject.SetActive(false);
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_coolTime > _timer)
        {
            return;
        }
        _currentPointerObject = eventData.pointerCurrentRaycast.gameObject;
        this.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_coolTime > _timer)
        {
            return;
        }
        if (_currentPointerObject && _currentPointerObject.TryGetComponent<Cell>(out Cell cell))
        {
            if (cell.CurrentCellType == CellTypes.SpawonPoint)
            {
                //生成
                var minion = Instantiate(_prefab, _currentPointerObject.transform);
                minion.HP = _initHP;
                minion.Atk = _initAtk;
                minion.MoveTime = _initMoveTime;
                minion.StartPos = cell.CellPos;
                minion.Interval = _interval;
                minion.MinionType = MinionType.Villan;
                minion.ID = _id;
                _villanList.Add(minion.gameObject);

            }
        }
        _image.raycastTarget = true;
        _button.gameObject.SetActive(true);
        _timer = 0f;
        this.transform.SetParent(UIManager.Instance.UIVillanSelectPanel.transform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
