using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxVida;
    Animator animator;

    float vida;
    
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        vida = maxVida;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
        animator = GetComponent<Animator>();

    }


    public void ReceiveDamage(float damage)
    {
        if (vida > 0)
        {
            vida -= damage;
            GameManager.GetInstance().GMActualizarVida(vida / maxVida);

            Debug.Log("ReceiveDamage: " + vida);
            if (vida <= 0)
            {
                SoundManager.GetInstance().playerDeathSound();
                animator.SetBool("playerMuerto", true); //ponemos el bool a true
                Destroy(GetComponent<Collider2D>()); //para que no le puedan atacar
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; //para que no pueda moverse
                Destroy(GetComponent<PhysicalAttack>()); //para que no pueda atacar
                Destroy(GetComponent<ElementalAttack>()); //para que no haga ataques elementales
                Destroy(GetComponent<ElementChanger>());
                GameManager.GetInstance().DestroyPauseMenu();
                Invoke("DestroyPlayer", 0.5f); //para que dé tiempo a la animación lo invocamos después           
            }
        }             
    }

    public void Healing(float hp) //hacemos otro método para curar
    {
        if ((vida + hp) > maxVida) //para que no pueda tener más vida que la máxima
        {
            vida = maxVida;
        }
        else
            vida += hp;

        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
    }

    public void DamageOnFall()
    {   
        // El jugador pierde un cuarto de vida al caer por un precipicio
        vida -= maxVida / 4;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            if (LevelManager.GetInstance() != null)
                LevelManager.GetInstance().PrimeraHabitacion();
        }
    }

    public void RespawnOnFall(Vector3 playerSpawnScale)
    {
        if (vida > 0)
        {
            transform.localScale = playerSpawnScale;
            RoomManager.GetInstance().SetUpPlayer(LevelManager.GetInstance().GetOrientacion(), transform);

            Debug.Log("RespawnOnFall: " + vida);
        }
    }

    void DestroyPlayer() //para destruirlo con tiempo y que se ponga la animación
    {
        Destroy(this.gameObject);
        GameManager.GetInstance().GMDestruirCanvas();
        LevelManager.GetInstance().EscenaDeMuerte();
    }
}
