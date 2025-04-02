using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienEnemy : MonoBehaviour
{
    public float health, maxHealth = 5f;
    [SerializeField] public Image healthBar;
    private Transform target;
    public float speed;
    [SerializeField] private GameObject alien1;
    [SerializeField] private GameObject alien2;
    [SerializeField] private GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        exit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            alien1.SetActive(false);
            alien2.SetActive(true);
            exit.SetActive(true);
        }
    }
}
