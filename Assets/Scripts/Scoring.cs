using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text your_time;
    public Text congrats;
    public Text rank;
    
    int time;

    Color currentColor = Color.red;
    Color targetColor = Color.red;
    int c = 0;
    List<Color> colors = new List<Color>();


    int firstPlace;
    int secondPlace;
    int thirdPlace;
    int fourthPlace;
    int fifthPlace;

    void Start()
    {
        time = PlayerPrefs.GetInt("LastGameTime");
        firstPlace = PlayerPrefs.GetInt("1st");
        secondPlace = PlayerPrefs.GetInt("2nd");
        thirdPlace = PlayerPrefs.GetInt("3rd");
        fourthPlace = PlayerPrefs.GetInt("4th");
        fifthPlace = PlayerPrefs.GetInt("5th");
        your_time.text = "you lasted: " + time.ToString() + " Seconds";

        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.red);

        if(IsHighScore())
        {
            SetHighScore();
        }
    }

    void SetHighScore()
    {
        if (time > firstPlace)
        {
            PlayerPrefs.SetInt("1st", time);
            rank.text = "You have the best time";
        }
        else if (time > secondPlace)
        {
            PlayerPrefs.SetInt("2nd", time);
            rank.text = "You have the 2nd best time";
        }
        else if (time > thirdPlace)
        {
            PlayerPrefs.SetInt("3rd", time);
            rank.text = "You have the 3rd best time";
        }
        else if (time > fourthPlace)
        {
            PlayerPrefs.SetInt("4th", time);
            rank.text = "You have the 4th best time";
        }
        else if (time > fifthPlace)
        {
            PlayerPrefs.SetInt("5th", time);
            rank.text = "You have the 5th best time";
        }
        Debug.Log("Score Set");
    }

    bool IsHighScore()
    {
        if(time > firstPlace || time > secondPlace || time > thirdPlace || time > fourthPlace || time > fifthPlace)
        {
            return true;
        }

        return false;
    }
    
    void Update()
    {
        if(IsHighScore())
        {
            currentColor = Color.Lerp(currentColor, targetColor, 0.05f);
            if(currentColor == targetColor)
            {
                if (c < 3)
                {
                    targetColor = colors[c];
                    c++;
                }
                else
                {
                    c = 0;
                }
            }
            congrats.color = currentColor;
            rank.color = currentColor;
        }
    }
}
