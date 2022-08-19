using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pausebutton : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _resume;
    void Start()
    {
        _panel.SetActive(false);
        _pause.onClick.AddListener(Pause);
        _resume.onClick.AddListener(Resume);
    }

    public void Pause()
    {
        Time.timeScale = 0;//��~
        _panel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;//�ĊJ
        _panel.SetActive(false);
    }
}
