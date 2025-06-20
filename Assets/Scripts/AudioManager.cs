using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AM;

    [Header("Audio Sources")] public AudioSource backgroundMusic1;
    public AudioSource backgroundMusic2;
    
    [Header("Audio Effects")] 
    public AudioSource pickupSound;
    public AudioSource jumpSound;
    public AudioSource damageSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    
    void Awake()
    {
        if (AM == null)
        {
            AM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayBackgroundForCurrentScene();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundForCurrentScene();
    }

    void PlayBackgroundForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
        backgroundMusic1.Stop();
        backgroundMusic2.Stop();

        
        if (sceneName == "Main")
        {
            backgroundMusic1.loop = true;
            backgroundMusic1.Play();
        }
        else if (sceneName == "Boss")
        {
            backgroundMusic2.loop = true;
            backgroundMusic2.Play();
        }
    }

    public void PlayPickupSound() => pickupSound?.Play();
    public void PlayJumpSound() => jumpSound?.Play();
    public void PlayDamageSound() => damageSound?.Play();
    public void PlayWinSound() => winSound?.Play();
    public void PlayLoseSound() => loseSound?.Play();

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
