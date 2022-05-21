using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerwalk : MonoBehaviour
{
    public float move = 5.0f;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Vector3 movement;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //direction change
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Elevator")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(0, 2, 0);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal")<0)
        {
            anim.SetBool("isWalkR", true);
            moveVelocity = Vector3.left;
            spriteRenderer.flipX = true;

        }
        else if(Input.GetAxis("Horizontal")>0)
        {
            anim.SetBool("isWalkR", true);
            moveVelocity = Vector3.right;
            spriteRenderer.flipX = false;
        }
        else
        {
            anim.SetBool("isWalkR", false);
        }
        transform.position += moveVelocity * move * Time.deltaTime;
    }
}