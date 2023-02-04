using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wurmspawner : MonoBehaviour
{
    public GameObject Enemy;
    public int WormAmount;

    private void Awake()
    {
        for (int i = 0; i < WormAmount; i++)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-30,30),Random.Range(-30,-170),0), Quaternion.identity);
        }
    }
}
