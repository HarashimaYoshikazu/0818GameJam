using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Scene1");
    }
}
