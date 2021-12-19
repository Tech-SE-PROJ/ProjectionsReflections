using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger1 : MonoBehaviour
{
    public bool roomTrigger1 = false;
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
        if((other.tag == "Player") && (enemycount.killedAllEnemies))
        {
            TransitionRoom(other);
        }
    }
    private void TransitionRoom(Collider2D other)
    {
        cam.minPos += camMinChange;
        cam.maxPos += camMaxChange;

        other.transform.position += playerChange;
        roomTrigger1 = true;
    }
}
