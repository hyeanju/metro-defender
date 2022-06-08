using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 100;
    public float speed;
    bool move = true;
    public GameObject eneitem;
    public Vector2 box;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.SetBool("isWalk", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3();
        vector3.x = this.transform.position.x;


        if (move == true)
        {
            if (vector3.x > 0)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }

    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 enemyvec = new Vector3();
        enemyvec = this.transform.position;

        if (other.tag == "Ladder")
        {
            if (enemyvec.y > 0)
            {
                this.transform.position = new Vector3(enemyvec.x, -24, enemyvec.z);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            anim.SetBool("isAtk", true);
            anim.SetBool("isWalk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Grinder")
        {
            anim.SetBool("isAtk", true);
            anim.SetBool("isWalk", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            anim.SetBool("isAtk", false);
            anim.SetBool("isWalk", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Grinder")
        {
            anim.SetBool("isAtk", false);
            anim.SetBool("isWalk", true);
        }
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        move = false; 
        anim.SetBool("isDie", true);
        Destroy(gameObject,1);
        GameObject Item = Instantiate(eneitem, transform.position, transform.rotation);
    }
}
