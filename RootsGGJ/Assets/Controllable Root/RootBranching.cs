using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBranching : MonoBehaviour
{
    public GameObject rootBranchPrefab;

    public List<GameObject> instantiatedTrails = new List<GameObject>();

    TrailRenderer trail;

    public bool stopBranching;

    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        StartCoroutine(RandomBranching());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomBranching()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));
        if (!stopBranching)
        {
            instantiatedTrails.Add(Instantiate(rootBranchPrefab, trail.gameObject.transform.position, Quaternion.identity));
            StartCoroutine(RandomBranching());
        }
    }
}
