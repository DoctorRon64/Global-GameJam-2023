using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public int PickupAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            PickupAmount = collision.GetComponent <Pickup>().PickupAmount;
            switch (collision.GetComponent<Pickup>().Pickuptype)
            {
                case 0: GetComponent<RootController2>().SpeedBoost(PickupAmount); break;
                case 1: Debug.Log("boo"); break;
                case 2: Debug.Log("hoo"); break;
                case 3: Debug.Log("woo"); break;
            }
        }
    }
}
