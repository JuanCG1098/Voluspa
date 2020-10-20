using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 500;
    int currentHealth;
    public bool tookDamage = false;
    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        tookDamage = true;
        Debug.Log("Boss recibe daño ." + tookDamage);

        // Play hurt animation
        animator.SetTrigger("Hurt");

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void StopCoroutine(object v)
    {
        throw new NotImplementedException();
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        // Die animation
        animator.SetBool("IsDead", true);

        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
