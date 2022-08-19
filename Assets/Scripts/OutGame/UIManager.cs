using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UIManager:Singleton<UIManager>
{
    GameObject _uIVillanSelectPanel = null;
    public GameObject UIVillanSelectPanel => _uIVillanSelectPanel;

    //FIX Me �Ȃ�ł��������̕ϐ������Ă���I
    List<VillanVIew> _villanVIews = new List<VillanVIew>();
    public List<VillanVIew> VillanViews => _villanVIews;

    /// <summary>
    /// �p�l���𓮓I�ɐ�������֐�
    /// </summary>
    public void CreateUIObject()
    {
        var list = Resources.LoadAll<VillanVIew>("Villans");
        var canvas = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIVillanSelectCanvas"));
        _uIVillanSelectPanel = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIVillanSelectPanel"), canvas.transform);      
        foreach (var i in list)
        {
            var v = GameObject.Instantiate(i, _uIVillanSelectPanel.transform);
            _villanVIews.Add(v);
        }

        if (!_moneyText)
        {
            _canvas = GameObject.Instantiate(Resources.Load<Canvas>("UIPrefabs/Canvas"));
            _moneyText = GameObject.Instantiate(Resources.Load<Text>("UIPrefabs/MoneyText"), _canvas.transform);
        }
        if (!_bossHPSlider)
        {
            _bossHPSlider = GameObject.Instantiate(Resources.Load<Slider>("UIPrefabs/Slider"),_canvas.transform);
        }
        if (!_timeText)
        {
            _timeText = GameObject.Instantiate(Resources.Load<Text>("UIPrefabs/TimeText"), _canvas.transform);
        }
    }

    public void OnUpdate()
    {
        _villanVIews.ForEach(x => x.OnUpdate());
    }

    Text _moneyText = null;
    Canvas _canvas = null;
    /// <summary>
    /// �����̕\�����X�V����
    /// </summary>
    /// <param name="value"></param>
    public void ChangeMoneyView(int value)
    {
        _moneyText.text = value.ToString();        
    }
    Slider _bossHPSlider = null;
    /// <summary>
    /// �{�X��HP�X���C�_�[���X�V����
    /// </summary>
    /// <param name="value"></param>
    public void ChangeHPSlider(int hp,int maxHP)
    {
        _bossHPSlider.maxValue = maxHP;
        _bossHPSlider.value = hp;
    }
    Text _timeText = null;
    /// <summary>
    /// �^�C�}�[�\�����X�V����
    /// </summary>
    /// <param name="num"></param>
    public void ChangeTimeText(int num)
    {
        _timeText.text = num.ToString();
    }
}
