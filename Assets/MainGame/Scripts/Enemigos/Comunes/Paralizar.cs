using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralizar : MonoBehaviour
{
    [SerializeField] float tiempoParalización;
    EnemyAttackOnCollision ataque;

    public void Paraliza()
    {
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
            
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;     
        Invoke("ParalizaAcaba", tiempoParalización);
    }

    void ParalizaAcaba()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
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
