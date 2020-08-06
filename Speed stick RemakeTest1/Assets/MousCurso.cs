using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousCurso : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 Mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Mpos;
    }
}
