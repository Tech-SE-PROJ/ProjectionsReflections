using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadGame()
    {
        SceneManager.LoadScene("StartScreen 1");
    }
    public void killGame()
    {
        Application.Quit();
    }
}
