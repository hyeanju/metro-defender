using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    Animator anim;
    public float cooltime;
    private float curtime;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curtime<=0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("isshot", true);
                Instantiate(bullet, pos.position, transform.rotation);
            }
            anim.SetBool("isshot", false);
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
}
