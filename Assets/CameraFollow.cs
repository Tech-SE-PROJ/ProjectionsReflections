using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targ;
    public float smooth;
    public Vector2 maxPos;
    public Vector2 minPos;
    private void FixedUpdate()
    {
        if (!targ)
        {
            return;
        }
        if (transform.position != targ.position)
        {
            Vector3 targPos = new Vector3(targ.position.x, targ.position.y, transform.position.z);
            targPos.x = Mathf.Clamp(targPos.x, minPos.x, maxPos.x);
            targPos.y = Mathf.Clamp(targPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targPos, smooth);
        }
    }
    void Update()
    {
        if (!targ)
        {
            return;
        }
    }
}
