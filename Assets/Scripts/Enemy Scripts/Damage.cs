using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.health -= damage;

            if (playerHealth.health <= 0) 
            {
                playerHealth.health = 0;
            }
            
            if (playerHealth.health >= 100) 
            { 
                playerHealth.health = 100;
            }
        }
    }
}
