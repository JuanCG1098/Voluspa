using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int health;

	public int numHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	void Update()
	{

		if(health > numHearts)
        {
			health = numHearts;
        }

		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < health)
			{
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}

			if (i < numHearts)
			{
				hearts[i].enabled = true;
			}
			else
			{
				hearts[i].enabled = true;
			}
		}
	}
	//public GameObject deathEffect;

	public Animator animator;

	public void TakeDamage(int damage)
	{
	
		health -= damage;
        //play hurt animation
        //animator.SetTrigger("Hurt");
        StartCoroutine(DamageAnimation());

		Debug.Log("PLAYER: Vida Actual -> " + health);

		if (health <= 0)
		{
			Debug.Log("PLAYER: Muriendo");
			Die();
		}
	}

	void Die()
	{
		Debug.Log("PLAYER DEAD! | GAME OVER");

		// Die animation
		animator.SetBool("IsDead", true);

		// Agregar una pausa de 3 segundos para que se visualice la animacion de muerte
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}
