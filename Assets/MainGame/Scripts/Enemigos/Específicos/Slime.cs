using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject slime;
    
    public void InstanciarSlimes()
    {
        

        Vector2 posicionSlime = transform.position;
        Vector2 tamanoSlime = transform.localScale / 4;
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x + tamanoSlime.x, posicionSlime.y + tamanoSlime.x), transform.rotation);
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x - tamanoSlime.x, posicionSlime.y + tamanoSlime.x), transform.rotation);
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x + tamanoSlime.x, posicionSlime.y - tamanoSlime.x), transform.rotation);
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x - tamanoSlime.x, posicionSlime.y - tamanoSlime.x), transform.rotation);
    }  
}


