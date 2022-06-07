using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public int damage = 30;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * (-1) * speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(other.tag == "Enemy")
        {
            enemy.GetDamage(damage);
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

}