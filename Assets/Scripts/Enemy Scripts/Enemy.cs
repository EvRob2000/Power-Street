using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth = 5f;
    [SerializeField] public Image healthBar;
    public float moveSpeed = 2f;
    Rigidbody rb;
    [SerializeField] private Transform target;
    Vector2 moveDirection;
    [SerializeField] private FameManager fameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            /*float angle = Mathf.Atan2(direction.x, direction.y * Mathf.Rad2Deg);
            rb.rotation = angle;*/
        }

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            fameManager.fame++;
        }
    }
}
