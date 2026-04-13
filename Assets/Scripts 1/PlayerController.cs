using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float rotationSpeed;
    [SerializeField] float Speed;

    InputAction move;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Player/move");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float slopeAngle = Mathf.Abs(transform.localEulerAngles.y - 180);
        float speedMultiplayer = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
        Vector2 moveVector = move.ReadValue<Vector2>();
        rb.AddForce(transform.forward * Speed * Time.fixedDeltaTime);
        transform.Rotate(0, moveVector.x * rotationSpeed * speedMultiplayer * Time.fixedDeltaTime, 0);
        


    }
}
