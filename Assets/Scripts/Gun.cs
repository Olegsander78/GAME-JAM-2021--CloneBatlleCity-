using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 10f;
    public float ShotPeriod = 2f;
    public AudioSource ShotSound;
    private float _timer;
    public KeyCode ShotButton;
    public bool IsPlayerOneGun;
    public bool IsPlayerTwoGun;
    public bool IsEnemyGun;
    public Bullet Bullet;
    

    void Update()
    {

        if (IsPlayerOneGun)
        {
            Bullet.IsPlayerOneBullet = true;
            Bullet.IsPlayerTwoBullet = false;
            Bullet.IsEnemyBullet = false;
        }
        if (IsPlayerTwoGun)
        {
            Bullet.IsPlayerOneBullet = false;
            Bullet.IsPlayerTwoBullet = true;
            Bullet.IsEnemyBullet = false;
        }

        _timer += Time.deltaTime;
        if (_timer > ShotPeriod)
        {
            if (Input.GetKeyDown(ShotButton))
            {
                _timer = 0f;
                CreateBullet();               
            }
        }
    }

    public void CreateBullet()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Spawn.up * BulletSpeed;
        ShotSound.Play();
    }
}
