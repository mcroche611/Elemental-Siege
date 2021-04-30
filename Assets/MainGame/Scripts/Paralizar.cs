using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralizar : MonoBehaviour
{
    [SerializeField] float tiempoParalización;
    public void Paraliza()
    {
        CancelInvoke("ParalizaAcaba");
        GetComponent<EnemyAttackOnCollision>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;     
        Invoke("ParalizaAcaba", tiempoParalización);
    }

    void ParalizaAcaba()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<EnemyAttackOnCollision>().enabled = true;
    }

    private void OnDestroy()
    {
        CancelInvoke("ParalizaAcaba");
    }
}
