using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController2 : MonoBehaviour
{
    public float moveSpeed = 5;
    public float boostMultiplier = 1.5f;
    public float sneakMulitplier = 0.7f;
    public float steeringSpeed = 5;

    float targetPosition;

    bool boosting;
    bool sneaking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AutoMove();
        Steering();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boosting = true;
        }
        else
        {
            boosting = false;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            sneaking = true;
        }
        else
        {
            sneaking = false;
        }
    }

    void AutoMove() 
    {
        if (boosting)
        {
            transform.Translate(Vector3.down * moveSpeed * boostMultiplier * Time.deltaTime);
        }
        else if (sneaking)
        {
            transform.Translate(Vector3.down * moveSpeed * sneakMulitplier * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    void Steering()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movement * steeringSpeed * Time.deltaTime);
    }
}
