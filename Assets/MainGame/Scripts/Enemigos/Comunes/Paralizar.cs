using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralizar : MonoBehaviour
{
    [SerializeField] float tiempoParalización;
    EnemyAttackOnCollision ataque;
    [SerializeField]
    Animator animator;
    Rigidbody2D rb;

    public void Paraliza()
    {
        animator.enabled = false;
        CancelInvoke("ParalizaAcaba");
        ataque = GetComponent<EnemyAttackOnCollision>();
        if (ataque != null)
            ataque.paralizado = true;
        else
        {
            Archer ataqueArco = GetComponentInChildren<Archer>();
            if (ataqueArco != null)          
                ataqueArco.paralizado = true;
            else
            {
                EspadaGuard ataqueEspada = GetComponentInChildren<EspadaGuard>();
                if (ataqueEspada != null)
                    ataqueEspada.paralizado = true;
            }                      
        }

        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;     
        Invoke("ParalizaAcaba", tiempoParalización);
    }

    void ParalizaAcaba()
    {
        animator.enabled = true;
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }      
        if (ataque)
            ataque.paralizado = false;
        else
        {
            Archer ataqueArco = GetComponentInChildren<Archer>();
            if (ataqueArco != null)
                ataqueArco.paralizado = false;
            else
            {
                EspadaGuard ataqueEspada = GetComponentInChildren<EspadaGuard>();
                if (ataqueEspada != null)
                    ataqueEspada.paralizado = false;
            }
        }
    }

    private void OnDestroy()
    {
        CancelInvoke("ParalizaAcaba");
    }
}
