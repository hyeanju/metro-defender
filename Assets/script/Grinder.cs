using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour
{
    public float SpawnRate=0.2f;
    public float MakeTime;
    public bool make = false;
    public int gearcount = 10;
    public GameObject gear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(make == true)
        {
            MakeTime += Time.deltaTime;
            if (MakeTime >= SpawnRate)
            {
                MakeTime = 0f;
                GameObject Gear = Instantiate(gear, transform.position, transform.rotation);
                gearcount = gearcount - 1;
            }
            if(gearcount == 0)
            {
                make = false;
            }
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController.eneitem >= 10)
            {
                Debug.Log(" gp");
                if (Input.GetButtonDown("interaction"))
                {
                    playerController.eneitem = 0;
                    make = true;
                }
            }
        }
    }
}
