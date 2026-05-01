using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    #region Variables
    #region Actions
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction dodgeAction;
    private InputAction attackAction;
    private InputAction interactAction;
    private InputAction sprintAction;
    #endregion

    public int health;
    public int armor;

    bool invincible = false;
    public float invincTime;

    public bool sprinting = false;

    public Rigidbody rb;
    public float jumpForce;

    public LayerMask ground;

    Vector3 flatVelocity = Vector3.zero;

    private Vector2 moveAmt;
    private Vector2 lookAmt;

    public float walkSpeed;
    public float rotateSpeed = 100;

    public float Maxspeed = 50f;
    public Vector3 maxSpeed;
    public GameObject attackBox;

    public ArmorChecker armorChecker;
    #endregion
    private void Awake()
    {
        dodgeAction = InputSystem.actions.FindAction("Dodge");
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        interactAction = InputSystem.actions.FindAction("Interact");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0.5f;
        maxSpeed = new Vector3(Maxspeed, 0, Maxspeed);
        
    }
       
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        moveAmt = moveAction.ReadValue<Vector2>();
        lookAmt = lookAction.ReadValue<Vector2>();
        if (dodgeAction.WasPerformedThisFrame()) 
        {
            Debug.Log("Dodging");
            IFrame(invincTime);
        }
        
        if (attackAction.WasPerformedThisFrame()) 
        {
            StartCoroutine(Attack());
            Debug.Log("Attack"); 
        }
        if (interactAction.WasPerformedThisFrame()) 
        {
            Debug.Log("Interact");
        }
        if (sprinting)
        {
            flatVelocity.x = rb.linearVelocity.x;
            flatVelocity.z = rb.linearVelocity.z;
            flatVelocity.y = 0f;
            if (flatVelocity.magnitude <= 0.1f)
            {
                Debug.Log("not sprinting");
                sprinting = false;
            }
        }
        if (sprintAction.WasPerformedThisFrame()) 
        { 
            
            if (sprinting) {sprinting= false;
                Debug.Log("Not Spriting");
            }
            else if (IsGrounded())
                {
                Debug.Log("Sprint");
                sprinting = true;
                }
            
        }
        if (jumpAction.WasPerformedThisFrame())
        {
            Jump();
            Debug.Log("Jumping");
        }
    }
    private void FixedUpdate()
    {
        Walking();
        Rotating();
    }
    #region invincible
    public void IFrame(float invincTime)
    {
        if (!invincible)
        {
            StartCoroutine(IFrames(invincTime));
        }
    }

    private IEnumerator IFrames(float invincTime)
    {
        invincible = true;
        Debug.Log("Invincible");
        yield return new WaitForSeconds(invincTime);
        Debug.Log("Not invincible");
        invincible = false;
    }
    #endregion
    private IEnumerator Attack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackBox.SetActive(false);
    }
    public void TakeDamage(int incomingDamage) 
    {
        if (!invincible)
        {
            incomingDamage -= armor;
            if (incomingDamage > 0)
            {
                health -= (incomingDamage);
            }
        }
        if (health <= 0)
        {
            Die();
        }
    }
    private void Walking()
    {
        if (moveAmt == Vector2.zero && IsGrounded())
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.x = 0;
            velocity.z = 0;
            rb.linearVelocity = velocity;
            return;
        }
        Vector3 moveDir = new Vector3(moveAmt.x, 0, moveAmt.y);
        moveDir = transform.TransformDirection(moveDir.normalized);

        float currentSpeed = sprinting ? walkSpeed * 1.5f : walkSpeed;

        rb.AddForce(moveDir.x * currentSpeed, 0, moveDir.z * currentSpeed);
        moveAmt = Vector2.zero;

        if (flatVelocity.magnitude > maxSpeed.magnitude) 
        {
            Vector3 clamped = flatVelocity.normalized * Maxspeed;
            rb.linearVelocity = new Vector3(clamped.x, rb.linearVelocity.y, clamped.z);
        }
    }
    private void Rotating()
    {
            float rotationamount = lookAmt.x * rotateSpeed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0, rotationamount, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        
    }
    #region jump
    private void Jump() 
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private bool IsGrounded()
    {

        return Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), .2f, ground);
    }
    #endregion

    #region reputation
    
    #endregion
    public void UpdateArmor()
    {
        armor = armorChecker.ArmorData.armor;
    }
    private void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
}
