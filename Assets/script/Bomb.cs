using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3.0f)
        {
            anim.SetBool("isExplosion", true);
            Invoke("Destroy", 1f);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
