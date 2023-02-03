using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public float MoveSpeed;
    public float ScreenRes;
    private float ySpeed;
    public Rigidbody2D rb2d;
    Vector3 mousePosition;
    public bool GoingUnder;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        LookAndFollow();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(transform.up);
    }

    void LookAndFollow()
    {
        mousePosition.z = 0;

        while(!GoingUnder)
        {
            ySpeed += ScreenRes;
        }
        Vector3 movement = new Vector3(mousePosition.x, ySpeed, 0);
        transform.position = Vector3.Lerp(transform.position, movement, Time.deltaTime * MoveSpeed);
        

        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
