using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyCounter : MonoBehaviour
{
    private float enemyCounter;
    [SerializeField] private TextMeshProUGUI enemyCounterText;

    void Start()
    {
        enemyCounterText = GetComponent<TextMeshProUGUI>();    
    }
    void Update()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("Bot").Length;
        enemyCounterText.text = "Enemies: " + enemyCounter.ToString();
    }
}
