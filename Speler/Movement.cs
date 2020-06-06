using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector2 movement;
    public float moveSpeed = 1f;

    void Update()
    {
        Movement2D();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed);
    }

    void Movement2D()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
