
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float moveDirection;
    private bool facingRight = true;
    private bool isGrounded = true;

    public Rigidbody2D playerBody;
    public Transform t;
    public float maxSpeed;
    public float jumpHeight;
    public Collider2D pCollider;

    LayerMask layerMask = ~(1 << 2 | 1 << 8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }
    }

    void FixedUpdate()
    {
        playerBody.velocity = new Vector2((moveDirection) * maxSpeed, playerBody.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        moveDirection = value.x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
        }
    }

}