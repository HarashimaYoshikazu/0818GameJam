using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UIManager:Singleton<UIManager>
{
    GameObject _uIVillanSelectPanel = null;
    public GameObject UIVillanSelectPanel => _uIVillanSelectPanel;

    //FIX Me なんでこいつがこの変数持ってるんや！
    List<VillanVIew> _villanVIews = new List<VillanVIew>();
    public List<VillanVIew> VillanViews => _villanVIews;
    /// <summary>
    /// 召喚選択パネルを動的に生成する関数
    /// </summary>
    public void CreateVillanViewPanel()
    {
        var list = Resources.LoadAll<VillanVIew>("Villans");
        var canvas = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIVillanSelectCanvas"));
        _uIVillanSelectPanel = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIVillanSelectPanel"), canvas.transform);      
        foreach (var i in list)
        {
            var v = GameObject.Instantiate(i, _uIVillanSelectPanel.transform);
            _villanVIews.Add(v);
        }
    }

    public void OnUpdate()
    {
        _villanVIews.ForEach(x => x.OnUpdate());
    }

    Text _moneyText = null;
    Canvas _canvas = null;
    public void ChangeMoneyView(int value)
    {
        if (!_moneyText)
        {
            _canvas = GameObject.Instantiate(Resources.Load<Canvas>("UIPrefabs/Canvas"));
            _moneyText = GameObject.Instantiate(Resources.Load<Text>("UIPrefabs/MoneyText"),_canvas.transform);
        }
        _moneyText.text = value.ToString();        
    }
    Slider _bossHPSlider = null;
    Text _timeText = null;
}
