using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rB;
    CapsuleCollider2D cC;
    float horizontalInput;
    float verticalInput;
    [SerializeField] LayerMask groundLayer;

    [Header("Stats")]
    public float speed;
    public float jumpPower;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        cC = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rB.velocity = new Vector2(horizontalInput * speed, rB.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Jump();
        }
    }


    void Jump()
    {
        rB.velocity = new Vector2(rB.velocity.x, jumpPower);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(cC.bounds.center, cC.bounds.size - new Vector3(0.1f,0,0), 0f, Vector2.down, -1f, groundLayer);
    }
}
