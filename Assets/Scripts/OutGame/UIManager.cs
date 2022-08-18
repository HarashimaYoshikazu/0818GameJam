using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager:Singleton<UIManager>
{
    List<VillanVIew> _villanVIews = new List<VillanVIew>();
    /// <summary>
    /// �����I���p�l���𓮓I�ɐ�������֐�
    /// </summary>
    public void CreateVillanViewPanel()
    {
        var list = Resources.LoadAll<VillanVIew>("Villans");
        foreach (var i in list)
        {
            var canvas = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIVillanSelectCanvas"));
            var panel = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/UIVillanSelectPanel"),canvas.transform);
            var v = GameObject.Instantiate(i,panel.transform);
            _villanVIews.Add(v);
        }
    }
}
