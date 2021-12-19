using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    public Shooting Shooting;
    public Text enemyText, enemyText1, enemyText2;
    int enemiesLeft, enemiesLeft1, enemiesLeft2;
    public bool killedAllEnemies = false;
    public bool killedAllEnemies1 = false;
    public bool killedAllEnemies2 = false;
    public GameObject[] enemies, enemies1, enemies2;
    void Start()
    {

    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemies1 = GameObject.FindGameObjectsWithTag("Enemy1");
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy2");
        /*if (!(killedAllEnemies))
        {
            foreach (GameObject enemy in enemies)
            { Shooting.Shoot(); }
            
        }
        if(killedAllEnemies)
        {
            foreach (GameObject enemy in enemies1)
            { Shooting.Shoot(); }
        }
        if(!(killedAllEnemies1))
        {
            foreach (GameObject enemy in enemies2)
            { Shooting.Shoot(); }
        }
        if(killedAllEnemies1)
        {
            foreach (GameObject enemy in enemies2)
            { Shooting.Shoot(); }
        } //Doesn't work currently.*/
        enemyText.text = enemiesLeft.ToString();
        enemyText1.text = enemiesLeft1.ToString();
        enemyText2.text = enemiesLeft2.ToString();
        if (killedAllEnemies && killedAllEnemies1 && killedAllEnemies2)
        {
            SceneManager.LoadScene("YouWin");
        }
        enemiesLeft = enemies.Length;
        enemiesLeft1 = enemies1.Length;
        enemiesLeft2 = enemies2.Length;
        if ((enemiesLeft == 0))
        {
            killedAllEnemies = true;
        }
        if (enemiesLeft1 == 0)
        {
            killedAllEnemies1 = true;
        }
        if (enemiesLeft2 == 0)
        {
            killedAllEnemies2 = true;
        }
    }

        //Doesn't work (requires a bit more coding to make this work)
        /*void OnGUI()
        {
            if (killedAllEnemies)
            {
                enemyText.text = "All dead.";
            }
            if (killedAllEnemies1)
            {
                enemyText1.text = "All dead.";
            }
            if (killedAllEnemies2)
            {
                enemyText2.text = "All dead.";
            }
        }*/
}