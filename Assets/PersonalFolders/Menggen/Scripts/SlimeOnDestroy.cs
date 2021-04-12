using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOnDestroy : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject SpriteSlime;

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>();
        GetComponent<GameObject>();
    }
    /*private void OnDestroy()
    {
        GetComponent<EnemyHealth>();
        if ()
        {
            
        }
    }
    */
}


