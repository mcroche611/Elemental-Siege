using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float vidaplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vidaplayer);
        if (vidaplayer == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
