using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositivitySwitch : MonoBehaviour
{
    public GameObject negativeObject;
    public GameObject positiveObject;

    public bool positive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (positive)
        {
            positiveObject.SetActive(true);
            negativeObject.SetActive(false);
        }
        else
        {
            positiveObject.SetActive(false);
            negativeObject.SetActive(true);
        }
    }
}
