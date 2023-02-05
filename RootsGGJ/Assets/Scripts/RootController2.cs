using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RootController2 : MonoBehaviour
{
    public float moveSpeed = 5;
    public float boostMultiplier = 1.5f;
    public float sneakMulitplier = 0.7f;
    public float steeringSpeed = 5;
    public float boostAbility = 1.5f;

    public GameObject topImage1;
    public GameObject topImage2;

    public GameObject obstaclePool;
    PositivitySwitch[] obstacles;

    float targetPosition;

    bool boosting;
    bool sneaking;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = obstaclePool.GetComponentsInChildren<PositivitySwitch>();
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

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //Turnaround();
        }

        if (moveSpeed < 0)
        {
            topImage1.SetActive(false);
            topImage2.SetActive(true);
            foreach (PositivitySwitch obstacle in obstacles)
            {
                obstacle.positive = true;
            }
        }
        else
        {
            topImage1.SetActive(true);
            topImage2.SetActive(false);
            foreach (PositivitySwitch obstacle in obstacles)
            {
                obstacle.positive = false;
            }
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

    public void SpeedBoost(int _Value)
    {
        boostMultiplier = _Value;
        StartCoroutine(ResetAbilities());
    }

    public void HealthBoost(int _Value)
    {
        if (_Value == 1) { GetComponent<RootDeath>().IsInvulnarable = true; } 
        else { GetComponent<RootDeath>().IsInvulnarable = false; } 
       
        StartCoroutine(ResetAbilities());
    }
    
    IEnumerator ResetAbilities()
    {
        yield return new WaitForSeconds(2);
        boostMultiplier = boostAbility;
        GetComponent<RootDeath>().IsInvulnarable = false;
    }

    public void Turnaround()
    {
        moveSpeed = -moveSpeed;
        topImage1.SetActive(false);
        topImage2.SetActive(true);
    }

    public void TurnForward()
    {
        moveSpeed = Mathf.Abs(moveSpeed);
        topImage1.SetActive(true);
        topImage2.SetActive(false);
    }
}
