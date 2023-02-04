using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBranch : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    float randomLifetime;

    int randomInt;

    TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();

        randomInt = Random.Range(-1, 1);
        randomLifetime = Random.Range(0.3f, 1);

        verticalSpeed = Random.Range(2, 4);
        horizontalSpeed = Random.Range(2, 4);

        StartCoroutine(Lifetime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);

        if (randomInt == 0)
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(randomLifetime);
        GetComponent<RootBranch>().enabled = false;
    }
}
