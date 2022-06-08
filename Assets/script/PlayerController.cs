using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move = 5.0f;
    public bool isLeft = false;
    public int eneitem;
    public int gear;

    public float cooltime;
    private float curtime;

    public GameObject bullet;
    public Transform pos;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    public GameObject bomb;

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
        if (isLeft == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (isLeft == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //attack
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isShot", true);
                Instantiate(bullet, pos.position, transform.rotation);
            }
            else
            {
                anim.SetBool("isShot", false);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Bomb();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "eneitem")
        {
            eneitem++;
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("isWalkR", true);
            moveVelocity = Vector3.left;
            isLeft = true;

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalkR", true);
            moveVelocity = Vector3.right;
            isLeft = false;
        }
        else
        {
            anim.SetBool("isWalkR", false);
        }
        transform.position += moveVelocity * move * Time.deltaTime;
    }

    void Bomb()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            GameObject Bomb = Instantiate(bomb, pos.position, transform.rotation);
        }
    }
}