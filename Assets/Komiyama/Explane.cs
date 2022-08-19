using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explane : MonoBehaviour
{
    //クリックしたら画像を表示
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
