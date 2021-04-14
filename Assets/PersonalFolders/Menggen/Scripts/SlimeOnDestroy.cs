using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOnDestroy : MonoBehaviour
{
    public GameObject slime;
    public int cantidadDeDivisión;
    private void OnDestroy()
    {
        for (int i = 0; i < cantidadDeDivisión; i++)
        {
            Instantiate<GameObject>(slime, transform.position, transform.rotation);
        }
    }
}


