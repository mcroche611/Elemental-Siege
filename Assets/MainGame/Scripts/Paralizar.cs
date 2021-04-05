using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralizar : MonoBehaviour
{
    [SerializeField] float tiempoParalización;
    public void Paraliza()
    {
        CancelInvoke("ParalizaAcaba");
        GetComponent<EnemyRaycast>().DisminuirVelocidad(0f);
        GetComponent<EnemyAttackOnCollision>().enabled = false;
        Invoke("ParalizaAcaba", tiempoParalización);
    }

    void ParalizaAcaba()
    {
        GetComponent<EnemyRaycast>().RestablecerVelocidad();
        GetComponent<EnemyAttackOnCollision>().enabled = true;
    }

    private void OnDestroy()
    {
        CancelInvoke("ParalizaAcaba");
    }
}
