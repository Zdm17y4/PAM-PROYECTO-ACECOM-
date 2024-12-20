using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private float scorePointsBombs = 1f;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = scorePointsBombs.ToString("0");
    }
    
    public void scoreUp(float points)
    {
        scorePointsBombs += points;
    }
}
