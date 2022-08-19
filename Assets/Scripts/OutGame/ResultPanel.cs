using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    Button _againButton;
    [SerializeField]
    Button _titleButton;
    private void Awake()
    {
        _againButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("HarashimaScene");
        });
        _titleButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("");
        });
    }
}
