using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
	public int Score = 100;
	public int HP = 1;
	public GameObject ExplosionPrefab;
	public float Speed = 100f;
	public Transform Gun;
	public GameObject Bullet;
	public float BulletSpeed = 3f;
	public float MinFireTime = 1.5f;
	public float MaxFireTime = 3.5f;
	private bool _fire;
	public AudioSource ShotSound;
	public AudioSource Exploud;
	public Exploud AnimExploud;
	public Animator AnimatorExploud;
    public bool IsEnemyGun = true;
	public Bullet BulletScript;

	void Start()
	{
		_fire = false;
		StartCoroutine(WaitFire(Random.Range(MinFireTime, MaxFireTime)));
	}

	IEnumerator WaitFire(float t)
	{
		yield return new WaitForSeconds(t);
		_fire = true;
		StartCoroutine(WaitFire(Random.Range(MinFireTime, MaxFireTime)));
	}	

	void Update()
	{
		if (IsEnemyGun)
		{
			BulletScript.IsPlayerOneBullet = false;
			BulletScript.IsPlayerTwoBullet = false;
			BulletScript.IsEnemyBullet = true;
		}

		if (_fire)
		{
			_fire = false;			
			GameObject newBullet = Instantiate(Bullet, Gun.position, Gun.rotation);
			newBullet.GetComponent<Rigidbody2D>().velocity = Gun.up * BulletSpeed;
			ShotSound.Play();
		}
        if (HP <= 0)
        {
			
			//float randomZ = Random.Range(0, 360f);
			//Instantiate(ExplosionPrefab, transform.position, Quaternion.Euler(0, 0, randomZ));
			//Destroy(ExplosionPrefab, 0.3f);
			Exploud.Play();
			//FindObjectOfType<Exploud>().Animator.SetBool("isActive", true);			
			//FindObjectOfType<Exploud>().Animator.SetTrigger("Start");
			//GameControl.score += Score;
			//DestroyEnemyTank();
			Destroy(gameObject);
		}
    }
  //  public void DestroyEnemyTank()
  //  {
		////float randomZ = Random.Range(0, 360f);
		////Instantiate(ExplosionPrefab, transform.position, Quaternion.Euler(0, 0, randomZ));
		//AnimatorExploud.SetTrigger(TriggerExploud);
  //      Destroy(gameObject);
  //  }
}
