using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RootCollision : MonoBehaviour
{
    RootDeath death;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<RootDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        death.Die();
    }
}
