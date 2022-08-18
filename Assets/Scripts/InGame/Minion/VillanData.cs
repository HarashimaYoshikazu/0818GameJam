using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VillanData : MinionData
{
    [Header("�������̏��������")]
    [SerializeField, Tooltip("�~�j�I����1�}�X�������x�̏������l")]
    float _initMoveTime = 0f;
    public float InitMoveTime => _initMoveTime;

    [SerializeField, Tooltip("�ď����܂ł̃N�[���^�C���̏������l")]
    float _initCoolTime = 0f;
    public float InitCoolTime => _initCoolTime;

    [SerializeField, Tooltip("�������̐�����")]
    int _initCreateValue = 0;
    public int InitCreateValue => _initCreateValue;

    [SerializeField, Tooltip("�����ɕK�v�ȑΉ�")]
    int _initLevelUpValue = 0;
    public int InitLevelUpValue => _initLevelUpValue;

    [SerializeField, Tooltip("�A�C�R���̉摜")]
    Sprite _sprite = null;
    public Sprite GetSprite => _sprite;
}
