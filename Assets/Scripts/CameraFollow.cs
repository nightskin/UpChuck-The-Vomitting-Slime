using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 smoothing;
    private Vector2 velocity;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;



    public bool bounds;

    void FixedUpdate()
    {
        float xPos = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x ,smoothing.x);
        float yPos = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothing.y);

        transform.position = new Vector3(xPos, yPos,transform.position.z);

        if (bounds)
        {
            float cx = Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x);
            float cy = Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y);
            float cz = Mathf.Clamp(transform.position.z, minCamPos.z, maxCamPos.z);
            transform.position = new Vector3(cx,cy,cz);
        }
    }
}
