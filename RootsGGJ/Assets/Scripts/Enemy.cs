using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum StateEnum { Idle, Patrol, Attack }
    public StateEnum currentState;
    public float ViewDistance = 5;
	[SerializeField] private float cooldownTimer;
	public float CooldownStartTime;

	[Header("Reference Object")]
	public GameObject Player;

    private Vector3 target;
    NavMeshAgent agent;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = new Vector3(Random.Range(-30, 30), Random.Range(-20, -170), 0);
		transform.position = new Vector3(Random.Range(-30, 30), Random.Range(-20, -170), 0);
    }

	private void Update()
	{
        CheckState();
	}

	public void OnPlayerDead()
	{
        Player = GameObject.FindGameObjectWithTag("Player");
    }

	private void CheckState()
	{
        switch (currentState)
		{
			case StateEnum.Idle: IdleBehaviour(); break;
			case StateEnum.Patrol: PatrolBehaviour(); break;
			case StateEnum.Attack: AttackBehaviour(); break;
   		}
	}

	private void IdleBehaviour()
	{

		if (Vector3.Distance(transform.position, Player.transform.position) < ViewDistance)
		{
			currentState = StateEnum.Attack;
		}

		cooldownTimer = CooldownStartTime;
		cooldownTimer -= 1000 * Time.deltaTime;
		if (cooldownTimer < 0)
		{
            target = new Vector3(Random.Range(-30, 30), Random.Range(-20, -170), 0);
            currentState = StateEnum.Patrol;
		}

	}

	private void PatrolBehaviour()
	{
		cooldownTimer = CooldownStartTime;
		agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
		Vector3 AgentDesti = agent.destination;

		if (Vector3.Distance(transform.position, AgentDesti) < ViewDistance) {
			currentState = StateEnum.Idle;
		}

		if (Vector3.Distance(transform.position, Player.transform.position) < ViewDistance)
		{
			currentState = StateEnum.Attack;
		}
	}

	private void AttackBehaviour()
	{
		agent.SetDestination(Player.transform.position);
		agent.transform.rotation = Quaternion.RotateTowards(transform.rotation, Player.transform.rotation, 360);

		if (Vector3.Distance(transform.position, Player.transform.position) > ViewDistance * 2)
		{
			currentState = StateEnum.Patrol;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
