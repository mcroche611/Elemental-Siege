using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int vidaPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ReceiveDamage(int damage)
    {
        vidaPlayer -= damage;

        Debug.Log(vidaPlayer);
        if (vidaPlayer == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
