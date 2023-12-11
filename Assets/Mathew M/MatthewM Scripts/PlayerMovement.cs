using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode dash;
    public float speed;
    public float jumpAmount = 0.001f;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    public Rigidbody2D rb;
    private bool TouchingGrass;
    public LayerMask GroundGaming;
    public BoxCollider2D coll;

    void Start()
    {
        
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetKey(left))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(right))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyDown(jump))
        {
            bool TouchingGrass()
            {
                return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, GroundGaming);
            }
            if (TouchingGrass())
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(dash) && canDash)
        {
            StartCoroutine(Dash());
        }
        IEnumerator Dash()
        {
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            if (Input.GetKey(left))
            {
                rb.velocity = new Vector2(transform.localScale.x * dashingPower * -1, 0f);
            }
            else
            {
                rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            }
            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }
    }
}
