using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vector3 = new Vector3();
        vector3 = playerObject.transform.position;
        vector3.y = playerObject.transform.position.y + 7;
        vector3.z = -10;
        transform.position = vector3;
    }
}
