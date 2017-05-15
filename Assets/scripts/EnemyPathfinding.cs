using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform player;

    private void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

	private void Update()
    {
        agent.destination = player.position;
    }

}
