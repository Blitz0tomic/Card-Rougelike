using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    #region Variables
    #region Actions
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction interactAction;
    private InputAction sprintAction;
    private InputAction DrawAction;
    private InputAction NextAction;
    private InputAction PrevAction;
    private InputAction PlayCardAction;
    #endregion

    public CardController controller;
    public float health;
    public float armor = 0;

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

    //public int SelectedCard = 0;

    bool attackReady = true;

    public float baseLightningAttackMultiplier = 1f;

    public float lightningAttackMultiplier;


    public ProjectileSpawner projectile;
    #endregion
    private void Awake()
    {
        //bind input actions from the input action asset
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        interactAction = InputSystem.actions.FindAction("Interact");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        DrawAction = InputSystem.actions.FindAction("Draw");
        NextAction = InputSystem.actions.FindAction("Next");
        PrevAction = InputSystem.actions.FindAction("Previous");
        PlayCardAction = InputSystem.actions.FindAction("PlayCard");
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0.5f;
        maxSpeed = new Vector3(Maxspeed, 0, Maxspeed);
        Cursor.lockState = CursorLockMode.Locked;
        lightningAttackMultiplier = baseLightningAttackMultiplier;
    }

    



    void Update()
    {
        
        moveAmt = moveAction.ReadValue<Vector2>();
        lookAmt = lookAction.ReadValue<Vector2>();
        
        
        if (attackAction.WasPerformedThisFrame() && attackReady) 
        {
            StartCoroutine(Attack());
            Debug.Log("Attack"); 
        }

        if (interactAction.WasPerformedThisFrame()) 
        {
            Debug.Log("Interact");
        }
                
        //toggle sprinting on input, only allowed to start while grounded
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
        
        if (sprinting)
        {
            flatVelocity.x = rb.linearVelocity.x;
            flatVelocity.z = rb.linearVelocity.z;
            flatVelocity.y = 0f;
            //auto-cancel sprinting once the player has basically stopped moving
            if (flatVelocity.magnitude <= 0.1f)
            {
                Debug.Log("not sprinting");
                sprinting = false;
            }
        }
        if (jumpAction.WasPerformedThisFrame())
        {
            Jump();
            Debug.Log("Jumping");
        }

        if (DrawAction.WasPerformedThisFrame()) 
        {
            controller.Draw(1);
            
        }

        //if (NextAction.WasPerformedThisFrame())
        //{
        //    SelectedCard += 1;
        //    if (SelectedCard >= controller.Hand.Count)
        //    {
        //        SelectedCard = 0;
        //    }
        //}

        //if (PrevAction.WasPerformedThisFrame())
        //{
        //    SelectedCard -= 1;
        //    if (SelectedCard < 0)
        //    {
        //        SelectedCard = controller.Hand.Count - 1;
        //    }
        //}

        //if (PlayCardAction.WasPerformedThisFrame() && controller.Hand.Count > 0)
        //{
        //    controller.Hand[SelectedCard].OnPlay();
        //}
    }
    private void FixedUpdate()
    {
        Walking();
        Rotating();
    }
    
    private IEnumerator Attack()
    {
        attackReady = false;
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackBox.SetActive(false);
        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSecondsRealtime(.15f);
        attackReady = true;
    }
    public void TakeDamage(float incomingDamage) 
    {
        Debug.Log("attacked for " + incomingDamage + " damage");
        Debug.Log("armor is " + armor);
        if (armor > 0)
        {
            armor = Mathf.Max(0, armor - incomingDamage);
            Debug.Log("armor is now " + armor);
            return; // fully absorbed, health untouched regardless of overflow
        }
        health -= incomingDamage;
        Debug.Log("health is now " + health);
        if (health <= 0)
        {
            Die();
        }
    }
    private void Walking()
    {
        //stop horizontal movement if no input and grounded
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
        //moveAmt = Vector2.zero;

        //clamp horizontal speed to the max speed
        if (flatVelocity.magnitude > maxSpeed.magnitude) 
        {
            Vector3 clamped = flatVelocity.normalized * Maxspeed;
            rb.linearVelocity = new Vector3(clamped.x, rb.linearVelocity.y, clamped.z);
        }
    }

    //rotate the player horizontally based on look input
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

    
    
    private void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
}