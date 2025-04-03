using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriminalEnemy : MonoBehaviour
{
    public float health, maxHealth = 5f;
    [SerializeField] public Image healthBar;
    [SerializeField] private FameManager fameManager;
    private Transform target;
    public float speed;
    [SerializeField] private GameObject mug1;
    [SerializeField] private GameObject mug2;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            fameManager.fame--;
            fameManager.alleyway = true;
            mug1.SetActive(false);
            mug2.SetActive(true);
        }
    }
}
