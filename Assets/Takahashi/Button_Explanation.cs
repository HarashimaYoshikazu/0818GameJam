using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Explanation : MonoBehaviour
{
    [SerializeField, Header("������@�p�l��")] GameObject explanation = null;
    public void OnClick()
    {
        explanation.SetActive(true);
    }
}
