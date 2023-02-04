using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform mainCamera;

    public bool followThisRoot = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (followThisRoot)
        {
            mainCamera.position = new Vector3(0, transform.position.y, -10);
        }
    }
}
