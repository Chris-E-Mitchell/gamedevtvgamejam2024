using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private PlayerController playerController;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerController = FindFirstObjectByType<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {     
        if (playerController != null)
        {
            agent.destination = playerController.transform.position;
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
            Destroy(other.gameObject);
        }
    }
}
