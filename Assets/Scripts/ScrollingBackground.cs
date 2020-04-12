﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    private BoxCollider2D myBC;
    private Rigidbody2D rb;

    private float width;

    private float speed = -3f;

    // Start is called before the first frame update
    void Start()
    {
        myBC = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = myBC.size.x;
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < - 15f)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}
