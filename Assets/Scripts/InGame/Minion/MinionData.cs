using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MinionData : ScriptableObject
{
    [Header("ミニオン基本情報")]
    [SerializeField,Tooltip("ミニオンの種類")]
    MinionType _minionType = MinionType.None;
    public MinionType GetMinionType => _minionType;

    [SerializeField,Tooltip("ミニオンの初期化攻撃力")]
    int _initAtk = 0;

    [SerializeField, Tooltip("ミニオンの攻撃間隔")]
    float _interval = 0f;
    public float Interval => _interval;
    public int InitAtk => _initAtk;
    [SerializeField, Tooltip("ミニオンの初期化HP")]
    int _initHP = 0;
    public int InitHP => _initHP;

    [SerializeField, Tooltip("ミニオンのプレハブ")]
    MinionParamator _prefab = null;
    public MinionParamator Prefab => _prefab;
}

public enum MinionType
{
    None,
    Villan,
    Hero
}
