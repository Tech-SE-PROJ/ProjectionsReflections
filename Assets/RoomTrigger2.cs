using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger2 : MonoBehaviour
{
    public bool roomTrig2 = false;
    public EnemyScript enemycount;
    public Vector2 camMaxChange;
    public Vector2 camMinChange;
    public Vector3 playerChange;
    private CameraFollow cam;
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player") && (enemycount.killedAllEnemies1))
        {
            TransitionRoom(other);
        }
    }
    public void TransitionRoom(Collider2D other)
    {
        cam.minPos += camMinChange;
        cam.maxPos += camMaxChange;

        other.transform.position += playerChange;
        roomTrig2 = true;
    }
}
