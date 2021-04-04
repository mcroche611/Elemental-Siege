using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralizar : MonoBehaviour
{
    [SerializeField] float tiempoParalización;
    public void Paraliza()
    {
        CancelInvoke("ParalizaAcaba");
        //aquí iría el script de movimiento del enemigo
        GetComponent<Patrulla>().enabled = false;
        //faltaría el escript de ataque del enemigo también
        Invoke("ParalizaAcaba", tiempoParalización);
    }

    void ParalizaAcaba()
    {
        //aquí iría el script de movimiento del enemigo
        GetComponent<Patrulla>().enabled = true;
        //aquí iría el script de movimiento del enemigo
    }

    private void OnDestroy()
    {
        CancelInvoke("ParalizaAcaba");
    }
}
