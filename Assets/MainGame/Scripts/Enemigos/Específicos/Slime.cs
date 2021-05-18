using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject slime;
    
    public void InstanciarSlimes()
    {
        Debug.Log("Hola");

        Vector2 posicionSlime = transform.position;
        Vector2 tamanoSlime = transform.localScale / 4;
        SoundManager.GetInstance().slimeDeathSound();
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x + tamanoSlime.x, posicionSlime.y + tamanoSlime.x), transform.rotation);
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x - tamanoSlime.x, posicionSlime.y + tamanoSlime.x), transform.rotation);
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x + tamanoSlime.x, posicionSlime.y - tamanoSlime.x), transform.rotation);
        Instantiate<GameObject>(slime, new Vector2(posicionSlime.x - tamanoSlime.x, posicionSlime.y - tamanoSlime.x), transform.rotation);
    }  
}


