using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public float MoveSpeed;
    Vector3 mousePosition;
    public TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void FixedUpdate()
    {
        LookAndFollow();
        Color myColor = Color.white;
       
        trailRenderer.material.color = myColor;

        myColor = Color.red;
    }

    void LookAndFollow()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * MoveSpeed * horizontalInput);
        transform.Translate(Vector2.down * MoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            RootDied();
        }
    }

    void RootDied()
    {
        Debug.Log("obama gaming");
        Vector2 RespawnLocation = new Vector2(0, 0);
        transform.position = RespawnLocation;
    }
}
