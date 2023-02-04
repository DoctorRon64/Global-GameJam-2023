using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class RootBranching : MonoBehaviour
{
    public GameObject rootBranchPrefab;
    private GameObject rootBranchLibraryPrefab;

    public List<GameObject> instantiatedTrails = new List<GameObject>();
    public GameObject rootBranchLibrary;
    TrailRenderer trail;

    public bool stopBranching;

    // Start is called before the first frame update
    void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        StartCoroutine(RandomBranching());
        rootBranchLibraryPrefab = Instantiate(rootBranchLibrary);
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
            
            for (int i = 0; i < instantiatedTrails.Count; i++)
            {
                instantiatedTrails[i].transform.SetParent(rootBranchLibraryPrefab.transform);
            }

        }
    }
}
