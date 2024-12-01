using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);    
    }
}
