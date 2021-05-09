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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//al entrar en el trigger del baculo o de los ataques elementales

        if (collision.GetComponent<BaculoAttackOnCollision>() != null || collision.GetComponent<ActivateElementOnCollision>() != null)
        {
            animator.enabled = true;
            if (numeroRandom <= dropProbabilityPercentage)
            {
                Instantiate<GameObject>(Heartprefab, transform.position, transform.rotation);

            }
            //Debug.Log("numero random jarron: " + numeroRandom);
            Invoke("DestruyeJarron", 2f);
        }
    }
   void DestruyeJarron()
    {
        Destroy(this.gameObject);
    }
}
