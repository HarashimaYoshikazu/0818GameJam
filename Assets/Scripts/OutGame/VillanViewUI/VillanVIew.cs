using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class VillanVIew : MonoBehaviour
{
    [SerializeField]
    int _id = 1;

    int _atk = 0;
    int _hP = 0;
    float _moveTime = 0f;

    float _coolTime = 0f;
    int _createValue = 0;
    int _levelUpValue = 0;

    private void Awake()
    {
        InitData();
    }



    void InitData()
    {
        var image = GetComponent<Image>();
        var data = Resources.Load<VillanData>($"VillanData/Villan{_id}");
        _atk = data.InitAtk;
        _hP = data.InitHP;
        _moveTime = data.InitMoveTime;
        _coolTime = data.InitCoolTime;
        _createValue = data.InitCreateValue;
        _levelUpValue = data.InitLevelUpValue;
        image.sprite = data.GetSprite;
    }
}
