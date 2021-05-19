using UnityEngine;

public class CorazonVida : MonoBehaviour
{
    [SerializeField]
    float vidaRegenerada; //vida que va a regenerar al jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null) //si detecta al jugador
        {
            SoundManager.GetInstance().curarSound();//sonido de curar
            collision.GetComponent<Health>().Healing(vidaRegenerada); //lo cura
            Destroy(gameObject); //se destruye
        }
    }
}
