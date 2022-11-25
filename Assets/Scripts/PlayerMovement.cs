using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] int speed = 5;
    [SerializeField] float jumpForce = 500f;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator anim;

    const int IDLE = 0;
    const int RUN = 1;

    // Start is called before the first frame update
    void Start() 
    {
        if(rigid==null)
            rigid = GetComponent<Rigidbody2D>();
        if(anim==null)
            anim = GetComponent<Animator>();
        anim.SetInteger("run", IDLE);
    }

    // Update is called once per frame
    void Update() 
    {
        movement = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    void FixedUpdate() 
    {
        if(movement<0 || movement>0)
        {
            rigid.velocity = new Vector2(movement*speed, rigid.velocity.y);
            anim.SetInteger("run", RUN);
        }
        if(movement==0)
            anim.SetInteger("run", IDLE);
        if(movement<0 && isFacingRight || movement>0 && !isFacingRight)
            Flip();
        if(jumpPressed && isGrounded)
            Jump();
    }

    void Flip() 
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump() 
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag=="Ground")
            isGrounded = true;
    }
}
