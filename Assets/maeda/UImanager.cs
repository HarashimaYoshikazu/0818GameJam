using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public Text time_text;
    public Text life_text;
    public Text funds_text;
    public Slider hp_bar;
    private float _elapsed;
    private float _life;
    private float _funds;

    void Start()
    {
        _elapsed = 300;
        _life = 25;
        _funds = 100;

        hp_bar.maxValue = _life;
        hp_bar.value = hp_bar.maxValue;
    }

    void Update()
    {
        _elapsed -= Time.deltaTime;
        TimeUI();
        LifeUI();
        FundsUI();
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _life -= 2;
        }
        hp_bar.value = _life;
    }
    public void TimeUI()
    {
        if (_elapsed > 0)
        {
            var span = new TimeSpan(0, 0, (int)_elapsed);
            time_text.text = span.ToString(@"mm\:ss");
        }
    }
    public void LifeUI()
    {
        life_text.text = _life.ToString();
    }
    public void FundsUI()
    {
        funds_text.text = _funds.ToString();
    }    
}
