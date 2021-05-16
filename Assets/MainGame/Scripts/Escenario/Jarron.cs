using UnityEngine;

public class Jarron : MonoBehaviour
{
    [SerializeField]
    float dropProbabilityPercentage; //probabilidad del 0 a 100%

    [SerializeField]
    GameObject Heartprefab;
    [SerializeField]
    Animator animator;
    float numeroRandom;

    private void Start()
    {
        numeroRandom = Random.Range(1, 100); //numero entre 1 y 100 para que si la probabilidad es 0 no salga drop

        LevelManager levelManager = LevelManager.GetInstance();

        if (levelManager != null)
        {
            if (!levelManager.HabiaEntradoAntes())         
                levelManager.NuevoJarron(this.name);
            //si ya la ha pisado
            else
            {
                levelManager.IniJarron(this.gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//al entrar en el trigger del baculo o de los ataques elementales

        if (collision.GetComponent<BaculoAttackOnCollision>() != null || collision.GetComponent<ActivateElementOnCollision>() != null)
        {
            animator.enabled = true;            

            if (LevelManager.GetInstance() != null)
                LevelManager.GetInstance().DestruirJarron(this.gameObject);
            Destroy(GetComponent<BoxCollider2D>());
            Invoke("SoltarCorazon", 0.75f);
        }
    }

    private void SoltarCorazon()
    {
        if (numeroRandom <= dropProbabilityPercentage)       
            Instantiate<GameObject>(Heartprefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
