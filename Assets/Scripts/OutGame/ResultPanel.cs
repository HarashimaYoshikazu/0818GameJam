using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    Button _sceneOneButton;
    [SerializeField]
    Button _titleButton;
    [SerializeField]
    Button _sceneTwoButton;
    private void Awake()
    {
        _sceneOneButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("Scene1");
        });
        _sceneTwoButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scene2");
        });
        _titleButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("Title");
        });
    }
}
