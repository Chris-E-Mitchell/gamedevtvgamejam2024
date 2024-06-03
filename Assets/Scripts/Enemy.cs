using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private PlayerController playerController;
    private ZombieSpawn zombieSpawn;
    private StartScreen startScreen;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        zombieSpawn = FindFirstObjectByType<ZombieSpawn>();
        startScreen = FindFirstObjectByType<StartScreen>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {     
        if (playerController != null)
        {
            agent.destination = playerController.transform.position;
        }
        else
        {
            agent.isStopped = true;
        }

        if (agent.velocity != Vector3.zero)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy caught player!");
            playerController.Die();
            zombieSpawn.SetSpawning(false);
            startScreen.EndGame();

        }
    }
}
