using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody rb;
    private Camera mainCamera;

    public Vector2 MoveInput { get; set; }
    public Vector2 LookInput { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(MoveInput.x, 0, MoveInput.y); 

        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }

    private void Look()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(mainCamera.ScreenPointToRay(LookInput), out hit);
        
        if (!hasHit) { return; }

        Vector3 lookTowards = new Vector3(hit.point.x, rb.position.y, hit.point.z);
        transform.LookAt(lookTowards);
    }
}
