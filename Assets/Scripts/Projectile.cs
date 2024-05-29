using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float bulletLife = 2f;

    private void Update()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;

        bulletLife -= Time.deltaTime;
        if (bulletLife < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Collision ignored with: " + other.gameObject.name);
            return;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy: " + other.gameObject.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Hit other:" + other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
