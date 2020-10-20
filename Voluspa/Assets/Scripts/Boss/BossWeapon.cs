using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 2;

    public Animator animator;

    public Transform attackEnemy;


    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    public void Attack()
    {
        //Debug.Log("BOSS: Ataque Realizado");
        if (gameObject.GetComponent<Enemy>().tookDamage == false)
        {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackEnemy.position, attackRange, attackMask);
            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("BOSS: Ataque Exitoso! (Daño: " + attackDamage + ")");
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
        else
        {
            gameObject.GetComponent<Enemy>().tookDamage = false;
            Debug.Log("tookDamage paso a: " + gameObject.GetComponent<Enemy>().tookDamage);
        } 
    }

    private void OnDrawGizmosSelected()
    {
        if (attackEnemy == null)
            return;

        Gizmos.DrawWireSphere(attackEnemy.position, attackRange);
    }


    //void OnDrawGizmosSelected()
    //{
    //    Debug.Log("OnDrawGizmos");
    //    Vector3 pos = transform.position;
    //    pos += transform.right * attackOffset.x;
    //    pos += transform.up * attackOffset.y;

    //    Gizmos.DrawWireSphere(pos, attackRange);
    //}
}
