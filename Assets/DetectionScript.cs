using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public bool PlayerInArea;
    public Transform Player;
    public string detection = "Player";
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag(detection))
        {
            PlayerInArea = true;
            Player = collider.gameObject.transform;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag(detection))
        {
            PlayerInArea = false;
            Player = null;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
