using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SelectionMenuCharacter : MonoBehaviour
{
    private int index;
    [SerializeField] private Image image;

    [SerializeField] private TextMeshProUGUI name;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("JugadorIndex");
        
        if(index > gameManager.characaters.Count - 1)
        {
            index = 0;
        }
    }

    private void ChangeScene()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        image.sprite = gameManager.characaters[index].image;
        name.text = gameManager.characaters[index].name;
    }

    public void NextCharacter()
    {
        if(index == gameManager.characaters.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        ChangeScene();
    }
    public void BackCharacter()
    {
        if (index == 0)
        {
            index = gameManager.characaters.Count - 1;
        }
        else
        {
            index -= 1;
        }
        ChangeScene();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
