using UnityEngine;

public class EspadaGuard : MonoBehaviour
{

    [SerializeField]
    float attackCoolDown = 1.5f;
    [SerializeField]
    float attackDuration = 1f; //cuidado con esto para que no salga negativo

    GameObject guardSword;
    Rigidbody2D enemyRigidbody;

    bool attackEnabled = true;
    [HideInInspector] public bool paralizado = false;

    private void Start()
    {
        enemyRigidbody = GetComponentInParent<Rigidbody2D>();
        guardSword = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackEnabled && !paralizado)
        {
            Freeze();  //se quita el movimiento del enemigo
            guardSword.transform.rotation = Rotation(collision.transform.position);
            guardSword.SetActive(true);   //nada más entrar se activa la espada

            Invoke("Unfreeze", attackDuration); //se le devuelve el movimiento pasado e ataque
            Invoke("SwordDeactivate", Time.deltaTime); //y se desactiva acabada la duracion del ataque

            attackEnabled = false;
            Invoke("EnableAttack", attackCoolDown);
        }
    }
 
    private void OnTriggerStay2D(Collider2D collision) //si permanece dentro el jugador
    {
        if (attackEnabled && !paralizado)
        {
            Freeze();  //se quita el movimiento del enemigo
            guardSword.transform.rotation = Rotation(collision.transform.position);
            guardSword.SetActive(true);    //nada más entrar se activa la espada

            Invoke("Unfreeze", attackDuration); //se le devuelve el movimiento pasado e ataque
            Invoke("SwordDeactivate", Time.deltaTime); //y se desactiva acabada la duracion del ataque

            attackEnabled = false;
            Invoke("EnableAttack", attackCoolDown);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) //al salir el jugador nos aseguramos de que pare
    {
        CancelInvoke("EnableAttack");
        attackEnabled = true;
    }
    
    private void SwordDeactivate()
    {
        guardSword.SetActive(false);
    }

    private Quaternion Rotation(Vector2 posJugador)
    {
        Vector2 vector = new Vector2(posJugador.x - transform.position.x, posJugador.y - transform.position.y);
        float angulo = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        return Quaternion.Euler(new Vector3(0f, 0f, angulo - 90));
    }

    private void Unfreeze()
    {
        enemyRigidbody.constraints = RigidbodyConstraints2D.None;
        enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Freeze()
    {
        CancelInvoke("Unfreeze");
        enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void EnableAttack()
    {
        attackEnabled = true;
    }
}
