using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    
    public GameObject hp_bar;
    public GameObject ammo_bar;
    public GameObject timer;
    float time;

    private void Start()
    {
        time = 0;
        timer.GetComponent<Text>().text = "time: " + time.ToString();
    }

    private void Update()
    {
        time += Time.deltaTime;
        int score_r = Mathf.RoundToInt(time);
        timer.GetComponent<Text>().text = "time: " + score_r.ToString();
    }

    public float GetHP()
    {
        return hp_bar.GetComponent<Slider>().value;
    }

    public void IncreaseHP(float v)
    {
        hp_bar.GetComponent<Slider>().value += v;
    }

    public void DecreaseHP(float v)
    {
        hp_bar.GetComponent<Slider>().value -= v;
    }

    public float GetAmmo()
    {
        return ammo_bar.GetComponent<Slider>().value;
    }

    public void DecreaseAmmo(float v)
    {
        ammo_bar.GetComponent<Slider>().value -= v;
    }

    public void IncreaseAmmo(float v)
    {
        ammo_bar.GetComponent<Slider>().value += v;
    }

    public void SaveTime()
    {
        int time = Mathf.RoundToInt(this.time);
        PlayerPrefs.SetInt("LastGameTime", time);
    }

}
