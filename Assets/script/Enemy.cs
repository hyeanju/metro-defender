using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 100;
    public float speed;
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3();
        vector3.x = this.transform.position.x;

        if (vector3.x > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(Vector2.left * speed *Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 enemyvec = new Vector3();
        enemyvec = this.transform.position;

        if (other.tag == "Ladder")
        {
            if(enemyvec.y > 0)
            {
                this.transform.position = new Vector3(enemyvec.x, -24, enemyvec.z);
            }
        }
    }

public void GetDamage(int damage)
    {
        hp -= damage;
        if(hp<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
