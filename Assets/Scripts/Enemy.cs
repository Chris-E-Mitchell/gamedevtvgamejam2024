using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private PlayerController playerController;
    private bool isPlayerDead = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerController = FindFirstObjectByType<PlayerController>();
    }

    private void Update()
    {     
        if (playerController != null)
        {
            agent.destination = playerController.transform.position;
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
