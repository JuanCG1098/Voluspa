using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public int trapDamage = 3;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Pisa Trampa y Recibe: " + trapDamage + " de Daño");
            col.GetComponent<PlayerHealth>().TakeDamage(trapDamage);
        }
    }

    //void OnCollisionEnter2D (Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Player Pisa Trampa y Recibe: " + trapDamage + " de Daño");
    //        GetComponent<PlayerHealth>().TakeDamage(trapDamage);
    //    }    
    //}
}
