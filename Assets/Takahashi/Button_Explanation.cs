using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Explanation : MonoBehaviour
{
    [SerializeField, Header("操作方法パネル")] GameObject explanation = null;
    public void OnClick()
    {
        explanation.SetActive(true);
    }
}
