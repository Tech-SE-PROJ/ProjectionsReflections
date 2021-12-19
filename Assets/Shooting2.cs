using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Timers;
public class Shooting2 : MonoBehaviour
{
    public RoomTrigger1 roomTrigger1;
    public GameObject[] enemies, enemies1, enemies2;
    public EnemyScript EnemyScript;
    public AudioClip PEWPEWPEW;
    public AudioSource source;
    private Rigidbody2D rb;
    private Vector2 move;
    public float detection;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform Player;
    public float bulletForce = 40f;
    public float range = 5.0f;
    private float timeBtwnShots = 0.55f;
    private float timestamp = 0.0f;
    public int numEnemies, numEnemies1, numEnemies2;
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody2D>();
        //InvokeRepeating("Shoot", 0.5f, 1.5f);
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemies1 = GameObject.FindGameObjectsWithTag("Enemy1");
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy2");
        if ((Time.time > timestamp))
            if (enemies.Length == 0 && roomTrigger1.roomTrigger1)
                //foreach (GameObject enemy in enemies1)
                Shoot();

        if (!Player)
        {
            return;
        }
        Vector3 direction = Player.position - transform.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 270f;
        rb.rotation = angle;
        direction.Normalize();
        move = direction;
    }
    public void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, (firePoint.rotation));
        source.Play();
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.rotation += 3.14f;
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(Bullet.gameObject, 6);
        timestamp = Time.time + timeBtwnShots;
    }
    /*public void ShootOnTime()
    {
        if (!(EnemyScript.killedAllEnemies))
            foreach (GameObject enemy in EnemyScript.enemies)
                InvokeRepeating("Shoot", 0.5f, 1.5f);
        if (EnemyScript.killedAllEnemies && !(EnemyScript.killedAllEnemies1))
            foreach (GameObject enemy in EnemyScript.enemies1)
                    InvokeRepeating("Shoot", 0.5f, 1.5f);
        if (EnemyScript.killedAllEnemies && EnemyScript.killedAllEnemies1)
            foreach (GameObject enemy in EnemyScript.enemies2)
                InvokeRepeating("Shoot", 0.5f, 1.5f);
    }*/
}
