using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector2 FirstPoint;
    bool FollowX = false;

    private void Start()
    {
        FirstPoint = transform.position;
    }

    void Update()
    {
        Following();
        if (Player.position.x >= FirstPoint.x)
         {
            Following();
         }
         else {
             if (Player.position.x < FirstPoint.x)
             {
                Stop();
             }
         }
    }
    void Following()
    {
        transform.position = new Vector3(Player.position.x, 0f, -10f);
    }
    void Stop()
    {
        transform.position = new Vector3(0f, 0f, -10f);
    }
}
