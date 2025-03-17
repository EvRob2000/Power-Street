using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject melee;
    public bool isAttacking;
    public float atkDuration = 0.3f;
    float atkTimer = 0f;

    private void Start()
    {
        melee.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMeleeTimer();

        if (Input.GetMouseButton(0))
        {
            OnAttack();
        }
    }

    private void OnAttack()
    {
        if (!isAttacking)
        {
            melee.SetActive(true);
            isAttacking = true;
        }
    }

    private void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= atkDuration)
            {
                atkTimer = 0f;
                isAttacking = false;
                melee.SetActive(false);
            }
        }
    }
}
