using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyitem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("erase",4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            erase();
        }
    }

    void erase()
    {
        Destroy(gameObject);
    }
}
