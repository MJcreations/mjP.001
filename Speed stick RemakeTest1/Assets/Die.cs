using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject player;
    Transform respown;

    private void Start()
    {
        respown = player.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.transform.position = respown.position;
    }
}
