using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int vidaPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance().SetHpPlayer(vidaPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        vidaPlayer = GameManager.GetInstance().GetVidaPlayer();

        Debug.Log(vidaPlayer);
        if (vidaPlayer == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
