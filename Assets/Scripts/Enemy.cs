using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent aI;
    public float enemySpeed;
    public Rigidbody enemyRb;
    private GameObject player1;
    private GameObject player2;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        aI = GetComponent<NavMeshAgent>();
        enemyRb = GetComponent<Rigidbody>();
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemySpeed = spawnManager.speed;

        aI.SetDestination(player1.transform.position);
        aI.SetDestination(player2.transform.position);
    }
}
