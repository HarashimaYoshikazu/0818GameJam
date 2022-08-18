using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MinionData : ScriptableObject
{
    [Header("�~�j�I����{���")]
    [SerializeField,Tooltip("�~�j�I���̎��")]
    MinionType _minionType = MinionType.None;
    public MinionType GetMinionType => _minionType;

    [SerializeField,Tooltip("�~�j�I���̏������U����")]
    int _initAtk = 0;
    public int InitAtk => _initAtk;
    [SerializeField, Tooltip("�~�j�I���̏�����HP")]
    int _initHP = 0;
    public int InitHP => _initHP;
}

public enum MinionType
{
    None,
    Villan,
    Hero
}
