using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rB;
    CapsuleCollider2D cC;
    public GameManager gameManager;
    public BlendingCams blendingCams;
    float horizontalInput;
    float verticalInput;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask platformLayer;


    [Header("Stats")]
    public float cameraShake;
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


        // call fall method
        if(Input.GetKeyDown(KeyCode.S) && IsOnPlatform())
        {
            FallDown();
        }

        // call jump method
        if (Input.GetKey(KeyCode.W) && IsGrounded())
        {
            Jump();
        }
 
    }

    // make the player fall down through a platform
    void FallDown()
    {
        blendingCams.ShakeCamera(2, cameraShake, 1f);
        cC.isTrigger = true;
        StartCoroutine(resetCc(0.8f));
    }

    // make the player jump
    void Jump()
    {
        rB.velocity = new Vector2(rB.velocity.x, jumpPower);
    }


    // Check if player is standing on ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(cC.bounds.center, cC.bounds.size - new Vector3(0.1f,0,0), 0f, Vector2.down, -1f, groundLayer);
    }

    // Check if player is standing on a platform
    private bool IsOnPlatform()
    {
        return Physics2D.BoxCast(cC.bounds.center, cC.bounds.size - new Vector3(0.1f, 0, 0), 0f, Vector2.down, -1f, platformLayer);
    }

    IEnumerator resetCc(float duration)
    {
        yield return new WaitForSeconds(duration);
        cC.isTrigger = false;
        Debug.Log("trigger reset");
    }

    // die when falling of level
    private void LateUpdate()
    {
        if (transform.position.y < -100)
        {
            gameManager.LoadScene(0);
        }
    }
}
