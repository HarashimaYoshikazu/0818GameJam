using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Explanation : MonoBehaviour
{
    [SerializeField, Header("������@�L�����p�X")] GameObject explanation = null;
    GameObject window = null;
    public void OnClick()
    {
        window = Instantiate(explanation);
    }

    public void DeleteWindow()
    {
        Destroy(window);
        Debug.Log("�֐����");
    }
}
