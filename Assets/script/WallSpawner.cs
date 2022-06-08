using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float moveRate = 2f;
    public float TimeRate;
    public GameObject broken;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (other.tag == "Player")
        {
            if (playerController.gear >= 10)
            {
                if (Input.GetKey("w"))
                {
                    Debug.Log("Çì¿¨");
                    TimeRate += Time.deltaTime;
                    if (TimeRate >= moveRate)
                    {
                        TimeRate = 0f;
                        broken.SetActive(false);
                        wall.SetActive(true);
                    }

                }
            }
        }
    }
}
