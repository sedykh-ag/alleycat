using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public float WalkSpeed;
    public float JumpSpeed;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * WalkSpeed, rb.velocity.y);

        if (Input.GetAxis("Vertical") > 0.1f && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
