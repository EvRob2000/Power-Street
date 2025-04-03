using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        CriminalEnemy criminalEnemy = collision.GetComponent<CriminalEnemy>();

        AlienEnemy alien = collision.GetComponent<AlienEnemy>();

        if(criminalEnemy != null)
        {
            criminalEnemy.TakeDamage(damage);
        }
        else if (alien != null)
        {
            alien.TakeDamage(damage);
        }
    }
}
