using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        healthText.text = $"{health}";

        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            yield return new WaitForSeconds(2);
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }
}
