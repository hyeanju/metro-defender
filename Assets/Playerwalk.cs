using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerwalk : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
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
        //방향 바꾸기
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX= Input.GetAxisRaw("Horizontal") == -1;
        }
        //애니메이션
        if(rigid.velocity.normalized.x < 0.3)
        {
            anim.SetBool("is walk", false);
        }
        else
        {
            anim.SetBool("is walk", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //이동
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)//right maxSpeed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))//Left MaxSpeed
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }
}