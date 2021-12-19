using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public AudioSource death;
    public Transform AttackCollider;
    public GameObject player;
    public Health health;
    public Transform Bullet;
    public Vector2 vec;
    void Start()
    {
        death = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!player)
        {
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Enemy")) || (other.gameObject.CompareTag("Enemy1")) || (other.gameObject.CompareTag("Enemy2")))
        {
            death.Play();
            Destroy(other.gameObject);
        }
        else if (other.collider.GetType() == typeof(BoxCollider2D))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                health.DamagePlayer(5);
                Destroy(this.gameObject);
            }
        }
        else if (other.collider.GetType() == typeof(CircleCollider2D))
        {
            if (other.gameObject.CompareTag("Player"))
            {

            }
        }
    }
    public void reflectionprojection(Rigidbody rb, Vector3 reflectionVector)
    {

    }
}
