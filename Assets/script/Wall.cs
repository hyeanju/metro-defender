using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int hp = 100;
    public int damage = 20;
    public float cooltime;
    private float curtime;
    public GameObject broken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        if (curtime <= 0)
        {
            hp -= damage;
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            broken.SetActive(true);
        }
    }
}
