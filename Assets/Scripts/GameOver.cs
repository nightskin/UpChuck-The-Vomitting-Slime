using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public ParticleSystem anim;

    void Awake()
    {
        anim = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(anim.IsAlive() == false)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
