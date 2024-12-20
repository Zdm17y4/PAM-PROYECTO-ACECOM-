using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    private void Start()
    {
        int indexPlayer = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameManager.Instance.characaters[indexPlayer].playableCharacter, transform.position, Quaternion.identity);
    }
}
