using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenBullets = 0.5f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePosition;

    private Rigidbody rb;
    private Camera mainCamera;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Look();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 value = inputValue.Get<Vector2>();
        moveInput = value;
    }

    private void Move()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y); 

        rb.MovePosition(transform.position + direction.normalized * moveSpeed * Time.deltaTime);

        //transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }

    private void OnLook(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        lookInput = inputValue;
    }

    private void Look()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(mainCamera.ScreenPointToRay(lookInput), out hit);
        
        if (!hasHit) { return; }

        Vector3 lookTowards = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        transform.LookAt(lookTowards);
    }

    private void OnAttack(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    private void Attack()
    {
        if (isAttacking)
        {
            if (attackTimer == 0f)
            {
                Instantiate(projectile, firePosition.position, transform.rotation);
            }
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeBetweenBullets)
            {
                attackTimer = 0f;
            }
        }
    }
}
