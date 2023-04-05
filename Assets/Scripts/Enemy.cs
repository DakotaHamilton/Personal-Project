using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    NavMeshAgent aI;
    Animator animator;

    public Rigidbody enemyRb;
    private GameObject player1;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player1 = GameObject.Find("Player 1");
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        aI = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        aI.SetDestination(player1.transform.position);
        aI.speed = spawnManager.armatureSpeed;

        animator.SetFloat("Speed", aI.speed);
    }
}
