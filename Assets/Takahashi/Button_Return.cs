using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Return : MonoBehaviour
{
    public void OnClick()
    {
        GameObject button_explanation = GameObject.Find("Button_Explanation");
        button_explanation.GetComponent<Button_Explanation>().DeleteWindow();
        Debug.Log("‚­‚è‚Á‚­‚µ‚½");
    }
}
