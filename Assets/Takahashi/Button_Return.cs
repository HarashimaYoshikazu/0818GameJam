using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Return : MonoBehaviour
{
    [SerializeField, Header("������@�p�l��")] GameObject explanation = null;
    public void OnClick()
    {
        explanation.SetActive(false);
    }
}
