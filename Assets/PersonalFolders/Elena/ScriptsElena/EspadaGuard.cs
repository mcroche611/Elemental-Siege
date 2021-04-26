using UnityEngine;

public class EspadaGuard : MonoBehaviour
{

    [SerializeField]
    float attackCooldown = 1.5f;
    [SerializeField]
    float attackDamage = 15f;
    [SerializeField]
    float attackDuration = 1f; //cuidado con esto para que no salga negativo

    float cooldown;
    Transform playerTransform;
    GameObject guardSword;
    Rigidbody2D enemyRigidbody;

    void Awake()
    {

    }
    private void Start()
    {
        enemyRigidbody = GetComponentInParent<Rigidbody2D>();
        guardSword = transform.GetChild(0).gameObject;
        guardSword.transform.position = transform.position;

    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerTransform = collision.transform;

        Freeze();  //se quita el movimiento del enemigo
        guardSword.SetActive(true);    //nada más entrar se activa la espada
        guardSword.transform.rotation = Rotation();
        Invoke("Unfreeze", attackDuration); //se le devuelve el movimiento pasado e ataque
        Invoke("SwordDeactivate", attackDuration); //y se desactiva acabada la duracion del ataque
        cooldown = attackCooldown; //el cooldown se resetea

    }
    private void OnTriggerStay2D(Collider2D collision) //si permanece dentro el jugador
    {

        
        Invoke("Attack", attackCooldown);
        Debug.Log("attack");


    }

    private void OnTriggerExit2D(Collider2D other) //al salir el jugador nos aseguramos de que pare
    {
        SwordDeactivate();
    }

    private void Attack()
    {
        if (cooldown <= 0)
        {
            Freeze();
            guardSword.SetActive(true);
            guardSword.transform.rotation = Rotation();
            Invoke("Unfreeze", attackDuration);            
            cooldown = attackCooldown;
            Invoke("SwordDeactivate", attackDuration);

        }

    }

    private void SwordDeactivate()
    {
        guardSword.SetActive(false);

    }

    private Quaternion Rotation()
    {
        Vector2 vector = new Vector2(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y);
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
        enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

    }
}
