using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float rotationSpeed;
    [SerializeField] float Speed;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private Vector3 pushBackForce;
    [SerializeField] private bool disabled = false;
    [SerializeField] private float disabledTime = 0.7f;
    public static Transform playerPos;
    InputAction move;
    private Rigidbody rb;
    [SerializeField] private float lastDisableTime = 0.75f;  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Player/move");
        playerPos = transform;
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += TakeDamage;
        lastDisableTime = Time.timeSinceLevelLoad;
    }

    void TakeDamage()
    {
        disabled = true;
        rb.AddForce(pushBackForce);
        Debug.Log("Stuknulsa");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.Linecast(transform.position, transform.position - transform.up * 2, groundLayer);
        Debug.DrawLine(transform.position, transform.position - transform.up * 2, Color.green);
        if (Time.timeSinceLevelLoad > lastDisableTime + disabledTime)
            disabled = false;
        if (isGrounded && !disabled)
        { 
        Vector2 moveVector = move.ReadValue<Vector2>();
        float slopeAngle = Mathf.Abs(transform.localEulerAngles.y - 180);
        float speedMultiplayer = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
        rb.AddForce(transform.forward * Speed * Time.fixedDeltaTime);
        transform.Rotate(0, moveVector.x * rotationSpeed * speedMultiplayer * Time.fixedDeltaTime, 0);
        }



    }
}
