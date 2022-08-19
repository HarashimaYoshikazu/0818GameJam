using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimaiton : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Enable()
    {
        _animator.SetTrigger("Enable");
    }

    public void Disable()
    {
        _animator.SetTrigger("Disable");
    }
}
