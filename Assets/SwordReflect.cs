using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordReflect : MonoBehaviour
{
    public AudioSource source;
    public Animator animator;
    public BoxCollider2D bulletCollider;
    public CircleCollider2D bulletTrigger;
    //public Transform attackCollider;
    public LayerMask bulletLayer;
    public float attackRange = 0.5f;
    private float SwingRate = 0.7f;
    private float NextSwing;

    void Start()
    {

        bulletTrigger = this.gameObject.GetComponent<CircleCollider2D>();
        bulletTrigger.isTrigger = true;
        bulletCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > NextSwing)
        {
            source.Play();
            bulletTrigger.isTrigger = false;
            NextSwing = Time.time + SwingRate;
            Attack();
            StartCoroutine("Reset");
            //bulletTrigger.isTrigger = true;

        }
        /*if(!(Input.GetKeyDown(KeyCode.Space)))
        {
            bulletTrigger.isTrigger = true;
        }*/
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        /*Collider2D[] bulletColliders = Physics2D.OverlapCircleAll(attackCollider.position, attackRange, bulletLayer);
        foreach (Collider2D bullet in bulletColliders)
        {
            Debug.Log("Hit bullet");
            //Destroy(bullet);
        }*/
    }

    /*void OnDrawGizmosSelected()
    {
        if (attackCollider == null)
            return;

        Gizmos.DrawWireSphere(attackCollider.position, attackRange);
    }*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.GetComponent<Collider>().GetType() == typeof(CircleCollider2D))
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    bulletTrigger.isTrigger = false;
                }
            }
        }
        //Is the following even required?
        else if (this.GetComponent<Collider>().GetType() == typeof(BoxCollider2D))
        {
            if (other.gameObject.CompareTag("Bullet"))
            {

            }
        }
    }
    //This is essentially like an advanced timer, almost required for 
    //the update function in unity since it's a coroutine
    IEnumerator Reset()
    {

        yield return new WaitForSeconds(0.6f);
        bulletTrigger.isTrigger = true;

    }
    /*void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<collider>().GetType() == typeof(CircleCollider2D))
        {
            Debug.Log("OnTriggerLeave");
            var magnitude = 2500;

            var force = transform.position - other.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
        }

    }*/
    /*public void fixedUpdate()
    {
        transform.Translate(inDirection * speed, Space.World);
    }
    public void onCollisionEnter2D(Collision2D collision)
    {
        var contact = collision.GetContact(0).point;
        //var contact = collision.contacts[0].point;
        Vector2 locateBullet = transform.position;
        var inNormal = (locateBullet - contact).normalized;
        inDirection = Vector2.Reflect(inDirection, inNormal);

    }
    // Make sword slashing animation, somehow make quarter-end animation in order to time reflection
    //rather than just pressing a key, because that causes the character to be invulnerable
}
*/
}