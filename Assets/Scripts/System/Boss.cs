using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    MinionParamator minionParamator;
    int _maxHP = 0;
    private void Awake()
    {
        minionParamator = GetComponent<MinionParamator>();
        _maxHP = minionParamator.HP;
        _lasthp = minionParamator.HP;
    }
    int _lasthp = 0;
    private void Update()
    {
        if (_lasthp != minionParamator.HP )
        {
            _lasthp = minionParamator.HP;
            UIManager.Instance.ChangeHPSlider(_lasthp,_maxHP);
        }
    }
}
