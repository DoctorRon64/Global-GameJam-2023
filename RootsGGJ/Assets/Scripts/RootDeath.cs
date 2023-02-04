using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootDeath : MonoBehaviour
{
    public GameObject playerRoot;
    public float respawnTime = 2;

    TrailRenderer trail;

    Vector3 spawnPoint;
    RootController movement;
    RootDeath death;
    RootBranching branching;
    CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<RootController>();
        death = GetComponent<RootDeath>();
        branching = GetComponent<RootBranching>();
        cameraFollow = GetComponent<CameraFollow>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(playerRoot, spawnPoint, Quaternion.identity);
        WitherRoot();
    }

    void WitherRoot()
    {
        trail.startColor = Color.gray;
        trail.endColor = Color.gray;
        trail.sortingOrder = 1;
        trail.emitting = false;
        movement.enabled = false;
        branching.stopBranching = true;
        branching.enabled = false;
        foreach (GameObject branch in branching.instantiatedTrails)
        {
            branch.GetComponent<TrailRenderer>().startColor = Color.gray;
            branch.GetComponent<TrailRenderer>().endColor = Color.gray;
        }
        cameraFollow.followThisRoot = false;
        death.enabled = false;
    }

    void Reset()
    {
        trail.startColor = Color.green;
        trail.endColor = Color.green;
        trail.sortingOrder = 2;
        trail.emitting = false;
        movement.enabled = true;
        branching.enabled = true;
        cameraFollow.followThisRoot = true;
        death.enabled = true;
    }

    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(playerRoot, spawnPoint, Quaternion.identity);
        death.enabled = false;
    }
}
