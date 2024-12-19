using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    private int numberEnemies;

    private void Start()
    {
        numberEnemies = GameObject.FindGameObjectsWithTag("Bot").Length;
        portal.SetActive(true);
    }

    private void Update()
    {
        numberEnemies = GameObject.FindGameObjectsWithTag("Bot").Length;
        Debug.Log(numberEnemies);

        if (numberEnemies == 0 && !portal.activeSelf)
        {
            portal.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && numberEnemies == 0)
        {
            Debug.Log("Se cambia de escena");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("workssss");
        }
    }
}
