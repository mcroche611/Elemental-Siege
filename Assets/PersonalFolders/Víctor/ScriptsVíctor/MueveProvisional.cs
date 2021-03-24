using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveProvisional : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
    }
}
