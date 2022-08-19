using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Explanation : MonoBehaviour
{
    [SerializeField, Header("‘€ì•û–@ƒpƒlƒ‹")] GameObject explanation = null;
    public void OnClick()
    {
        explanation.SetActive(true);
    }
}
