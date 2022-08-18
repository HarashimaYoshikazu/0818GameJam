using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VillanData : MinionData
{
    [Header("生成時の初期化情報")]
    [SerializeField, Tooltip("ミニオンの1マス動く速度の初期化値")]
    float _initMoveTime = 0f;
    public float InitMoveTime => _initMoveTime;

    [SerializeField, Tooltip("再召喚までのクールタイムの初期化値")]
    float _initCoolTime = 0f;
    public float InitCoolTime => _initCoolTime;

    [SerializeField, Tooltip("召喚時の生成数")]
    int _initCreateValue = 0;
    public int InitCreateValue => _initCreateValue;

    [SerializeField, Tooltip("強化に必要な対価")]
    int _initLevelUpValue = 0;
    public int InitLevelUpValue => _initLevelUpValue;

    [SerializeField, Tooltip("アイコンの画像")]
    Sprite _sprite = null;
    public Sprite GetSprite => _sprite;
}
