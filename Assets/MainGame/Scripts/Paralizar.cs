using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralizar : MonoBehaviour
{
    [SerializeField] float tiempoParalización;
    public void Paraliza()
    {
        CancelInvoke("ParalizaAcaba");
        GetComponent<EnemyMovement>().DisminuirVelocidad(0f);
        GetComponent<EnemyAttackOnCollision>().enabled = false;
        Invoke("ParalizaAcaba", tiempoParalización);
    }

    void ParalizaAcaba()
    {
        GetComponent<EnemyMovement>().RestablecerVelocidad();
        GetComponent<EnemyAttackOnCollision>().enabled = true;
    }

    private void OnDestroy()
    {
        CancelInvoke("ParalizaAcaba");
    }
}
