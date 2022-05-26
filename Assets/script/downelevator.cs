using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class downelevator : MonoBehaviour
{
    public GameObject Downicon;
    public Text press;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Downicon.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.transform.position = new Vector3(0, -3, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Downicon.SetActive(false);
            Destroy(press);
        }
    }
}
