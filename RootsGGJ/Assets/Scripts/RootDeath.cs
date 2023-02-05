using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RootDeath : MonoBehaviour
{
    public GameObject playerRoot;
    public GameObject blackFadePrefab;
    public float respawnTime = 2;
    public bool IsInvulnarable = false;

    public Color deadRootColour = Color.grey;

    Vector3 spawnPoint;

    TrailRenderer trail;
    RootController2 movement;
    RootDeath death;
    RootBranching branching;
    CameraFollow CameraFollow;
    [SerializeField] Enemy[] EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = FindObjectsOfType<Enemy>();
        CameraFollow = GetComponent<CameraFollow>();
        movement = GetComponent<RootController2>();
        death = GetComponent<RootDeath>();
        branching = GetComponent<RootBranching>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Die();
        }
    }

    public void Die()
    {
        if (!IsInvulnarable)
        {
            movement.TurnForward();
            Instantiate(playerRoot, spawnPoint, Quaternion.identity);
            gameObject.tag = "Untagged";
            for (int i = 0; i < EnemyScript.Length; i++)
            {
                EnemyScript[i].OnPlayerDead();
            }
            WitherRoot();
        }
    }

    void WitherRoot()
    {
        trail.startColor = deadRootColour;
        trail.endColor = deadRootColour;
        trail.sortingOrder = 1;
        trail.emitting = false;
        movement.enabled = false;
        branching.stopBranching = true;
        branching.enabled = false;
        foreach (GameObject branch in branching.instantiatedTrails)
        {
            branch.GetComponent<TrailRenderer>().startColor = deadRootColour;
            branch.GetComponent<TrailRenderer>().endColor = deadRootColour;
        }
        CameraFollow.followThisRoot = false;
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
        CameraFollow.followThisRoot = true;
        death.enabled = true;
    }
}
