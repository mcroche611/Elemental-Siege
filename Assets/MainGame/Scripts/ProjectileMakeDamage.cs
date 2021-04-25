using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMakeDamage : MonoBehaviour
{
    [SerializeField] float escaladoDeDaño;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy)
            enemy.QuitarVida(Formula());
    }

    private float Formula()
    {
        float bonoAlDaño = GameManager.GetInstance().Stat(GetComponent<ActivateElementOnCollision>().Elemento());
        float ataque = GameManager.GetInstance().Stat("");
        return (ataque + bonoAlDaño) * escaladoDeDaño;
    }
}
