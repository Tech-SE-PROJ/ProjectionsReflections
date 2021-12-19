using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health: MonoBehaviour
{
    public GameObject player;
    public int curHealth = 0;
    public int maxHealth = 300;

    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetHealth(maxHealth);
        curHealth = maxHealth;
    }

    void Update()
    {

        if (!player)
        {
            return;
        }
        if(curHealth == 0)
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("YouLose");
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
}
