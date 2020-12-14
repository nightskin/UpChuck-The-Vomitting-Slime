using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScores : MonoBehaviour
{
    public Text top1;
    public Text top2;
    public Text top3;
    public Text top4;
    public Text top5;

    void Start()
    {
        int score1 = PlayerPrefs.GetInt("1st");
        int score2 = PlayerPrefs.GetInt("2nd");
        int score3 = PlayerPrefs.GetInt("3rd");
        int score4 = PlayerPrefs.GetInt("4th");
        int score5 = PlayerPrefs.GetInt("5th");

        top1.text = "1st: " + score1.ToString();
        top2.text = "2nd: " + score2.ToString();
        top3.text = "3rd: " + score3.ToString();
        top4.text = "4th: " + score4.ToString();
        top5.text = "5th: " + score5.ToString();
    }
    
}
