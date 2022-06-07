using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Vector3 playvec = new Vector3();
        Vector3 laddervec = new Vector3();

        playvec = player.transform.position;
        laddervec = this.transform.position;

        if (other.tag == "Player")
        {
            if(playvec.y < 0)
            {
                if (Input.GetButtonDown("interaction"))
                {
                    player.transform.position = new Vector3(laddervec.x, 5, laddervec.z);
                }
            }
            else
            {
                if (Input.GetButtonDown("interaction"))
                {
                    player.transform.position = new Vector3(laddervec.x, -24, laddervec.z);
                }
            }
        }
    }
}
