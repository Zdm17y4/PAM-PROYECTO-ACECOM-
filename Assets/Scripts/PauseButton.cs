using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource gameSound;
    private bool pauseGame = false;
    private bool isMuted = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Mute();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {   

            if (pauseGame)
            {
                isMuted = false;
                gameSound.mute = isMuted;
                Resume();
            }
            else
            {
                isMuted = true;
                gameSound.mute = isMuted;
                Pause();
            }
        }
    }

    public void Mute()
    {
        isMuted = !isMuted;
        gameSound.mute = isMuted;

        /*
        if (isMuted)
        {
            Debug.Log("Audio muted");
        }
        else
        {
            Debug.Log("Audio unmuted");
        }*/
    }


    public void Pause()
    {
        pauseGame = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseGame = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}