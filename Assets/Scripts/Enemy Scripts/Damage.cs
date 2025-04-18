using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damage;
    public Animator anim;
    public bool canAttack;
    [SerializeField] private GameObject punchSound;


    private void Start()
    {
        punchSound.SetActive(false);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            StartCoroutine(EnemyAttack());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            StartCoroutine(EnemyAttack());
        }
    }

    private IEnumerator EnemyAttack()
    {
        punchSound.SetActive(true);
        anim.SetBool("isAttacking", true);
        canAttack = false;
        
        playerHealth.health -= damage;

        if (playerHealth.health <= 0)
        {
            playerHealth.health = 0;
        }

        yield return new WaitForSeconds(0.3f);

        anim.SetBool("isAttacking", false);
        punchSound.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        canAttack = true;
    }
}
