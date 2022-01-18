using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
	public Exploud Exploud;
	public GameObject ExploudPrefab;
	public GameControl GameControl;
	public PlayerControlOne PlayerControlOne;
	public PlayerControlTwo PlayerControlTwo;
	public Gun Gun;
	public bool IsPlayerOneBullet;
	public bool IsPlayerTwoBullet;
	public bool IsEnemyBullet;

	void Start()
	{
        //Destroy(gameObject, 4f);
    }
	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.transform.CompareTag("Headquarter"))
		{
			GameObject newExploud = Instantiate(ExploudPrefab, transform.position, transform.rotation);
			Destroy(newExploud.gameObject, 0.2f);
			coll.transform.GetComponent<Headquarter>().HP -= Damage;
			Destroy(gameObject);
		}

		if (coll.transform.CompareTag("Wall"))
		{			
			Destroy(gameObject);			
		}

		if (coll.transform.CompareTag("Block"))
		{			
			Destroy(gameObject);
		}
		if (coll.transform.CompareTag("WeekBlock"))
		{
			Destroy(coll.transform.gameObject);
			Destroy(gameObject);
		}
		if (coll.transform.CompareTag("Bullet"))
		{
			Destroy(coll.transform.gameObject);
			Destroy(gameObject);
        }
		if (coll.transform.CompareTag("Enemy"))
		{
			Destroy(gameObject);
			//GameObject newExploud = Instantiate(ExploudPrefab, transform.position, transform.rotation);
			//Destroy(newExploud.gameObject, 0.2f);
			coll.transform.GetComponent<EnemyControl>().HP -= Damage;						
			GameControl = FindObjectOfType<GameControl>();
			//bool _gunIsPlayerOne = FindObjectOfType<Gun>().IsPlayerOneGun;
			//bool _gunIsPlayerTwo = FindObjectOfType<Gun>().IsPlayerTwoGun;
			//Gun = FindObjectOfType<Gun>();
			GameControl.LeftEnemyTanks--;			
            if (IsPlayerOneBullet)
            {
				GameControl.ScorePlayerOne += 10;
            }
			if (IsPlayerTwoBullet)
            {
				GameControl.ScorePlayerTwo += 10;
            }
			if (IsEnemyBullet)
			{
				GameControl.ScorePlayerTwo += 0;
			}
			//if (FindObjectOfType<GunEnemy>().IsEnemyGun || FindObjectOfType<EnemyControl>().IsEnemy)
			//{
			//    GameControl.ScorePlayerTwo += 0;
			//}
			GameControl.UpdateTextPlayers();
        }
		if (coll.transform.CompareTag("PlayerOne"))
		{
            GameObject newExploud = Instantiate(ExploudPrefab, transform.position, transform.rotation);
            Destroy(newExploud.gameObject, 0.2f);
            coll.transform.GetComponent<PlayerControlOne>().HP -= Damage;			
			Destroy(gameObject);
			//Destroy(coll.transform.gameObject);
		}
		if (coll.transform.CompareTag("PlayerTwo"))
		{
            GameObject newExploud = Instantiate(ExploudPrefab, transform.position, transform.rotation);
            Destroy(newExploud.gameObject, 0.2f);
            coll.transform.GetComponent<PlayerControlTwo>().HP -= Damage;			
			Destroy(gameObject);
			//Destroy(coll.transform.gameObject);
		}

	}
	//public void HideExploud(GameObject exploudPrefab)
	//{
	//	//ExploudPrefab.SetActive(false);
 //       Destroy(exploudPrefab.gameObject, 0.4f);
	//}
}
