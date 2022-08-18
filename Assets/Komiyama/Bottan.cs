using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottan : MonoBehaviour
{
    //ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½‚çScene•Ï‚¦‚é
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
