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
        /* if (Player.position.x >= FirstPoint.x)
         {
             FollowX = true;
         }
         else {
             if (Player.position.x < FirstPoint.x)
             {
                 FollowX = false;
             }
         }

         if (FollowX == true)
         {
             Following();
         }*/
    }
    void Following()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, -10f);
    }
}
