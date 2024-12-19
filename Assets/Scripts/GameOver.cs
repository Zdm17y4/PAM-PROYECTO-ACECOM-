using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{ 
  public GameObject Panel;

  public void ShowGameOver()
    { 
        Panel.SetActive(true);
    }

  public void RestartLevel()
    {
        Debug.Log("Funciona Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PrincipalMenu()
    {
        Debug.Log("Funciona Menu Principal");
        SceneManager.LoadScene(0);
    }
}
