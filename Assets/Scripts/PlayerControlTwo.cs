using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlTwo : MonoBehaviour
{
	public int HP = 2;
	public Transform explosion;
	public AudioSource Exploud;
	private GameControl _gameControl;
	public Animator AnimatorExp;
	public Exploud AnimExploud;

	void Update()
	{
		if (HP <= 0)
		{			
			FindObjectOfType<GameControl>().PlayerTwoDead = true;
			float randomZ = Random.Range(0, 360f);
			//Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, randomZ));
			//Destroy(explosion.gameObject, 0.2f);
			Exploud.Play();
            //FindObjectOfType<Exploud>().Animator.SetTrigger("Start");
			FindObjectOfType<Exploud>().Animator.SetBool("isActive", true);
			Destroy(gameObject);
		}
	}
}
