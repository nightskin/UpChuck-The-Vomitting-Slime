using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private static SceneTransitions instance;
    [Header("Theme Music")]
    public AudioSource music;
    public AudioClip battle_theme;
    public AudioClip overworld_theme;
    public AudioClip title_music;
    public AudioClip game_over_theme;
    public AudioClip battle_win_theme;
    [Header("Scene Transitions")]
    public Animator anim;
    float t_time = 0.9f;
    
    public static SceneTransitions Instance { get { return instance; } }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", 0);
        PlayerPrefs.SetInt("Move1", 1);
        PlayerPrefs.SetInt("Move2", 2);
        PlayerPrefs.SetInt("Move3", 0);
        PlayerPrefs.SetInt("Move4", 0);

        PlayerPrefs.SetInt("LastOrSaved", 3);
    }

    IEnumerator SwitchScene(string sceneName)
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(t_time);
        SceneManager.LoadScene(sceneName);
    }

    public void PlayGame()
    {
        if(PlayerPrefs.GetInt("ExistingData") != 1)
        {
            NewGame();
            return;
        }
        StartCoroutine(SwitchScene("OverWorld"));
        music.clip = overworld_theme;
        music.Play();
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("ExistingData", 1);

        ResetLevel();

        StartCoroutine(SwitchScene("OverWorld"));
        music.clip = overworld_theme;
        music.Play();
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartBattle()
    {
        StartCoroutine(SwitchScene("BattleScene"));
        music.clip = battle_theme;
        music.Play();
    }

    public void WinBattle()
    {
        StartCoroutine(SwitchScene("BattleWin"));
        music.clip = battle_win_theme;
        music.Play();
    }

    public void EndBattle()
    {
        StartCoroutine(SwitchScene("OverWorld"));
        music.clip = overworld_theme;
        music.Play();
    }

    public void LoseBattle()
    {
        StartCoroutine(SwitchScene("GameOver"));
        music.clip = game_over_theme;
        music.Play();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
}
