using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explane : MonoBehaviour
{
    //�N���b�N������摜��\��
    [SerializeField]
    GameObject howToPlay = null;

    public void ClickExplain()
    {
        howToPlay.SetActive(true);
    }

    public void DeleteExplain()
    { 
        howToPlay.SetActive(false);
    }
}
