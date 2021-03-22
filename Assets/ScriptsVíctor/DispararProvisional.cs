using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararProvisional : MonoBehaviour
{
    public GameObject bolaElemental;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Instantiate<GameObject>(bolaElemental, transform.position, bolaElemental.transform.rotation);
        }
    }
}
