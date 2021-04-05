using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerSpeed : MonoBehaviour
{
    public GameObject icono;
    //tener una variable de speed en el script de Enemy
    Enemy enemy;
    public int enemySpeed = 3;
    [SerializeField] float disminucionVelocidad;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();

    }
    void OnEnable()
    {
        Instantiate<GameObject>(icono, new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2 + 0.5f, transform.position.z), icono.transform.rotation, transform);
        //Debug.Log(enemySpeed);
        //if (GetComponent<Mojado>().enabled == true)
        //{

        //}
        //no hace ni faltaaaa
        




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disminuirVelocidad()
    {

    }
}



/*a verrrrrrrrrrrrrrrr
 * lo que habria que hacer es hacer en el script de enemy una variable con serialize field de velocidad y un metodo que sirva para cambiarsela
 * tipo
 * private void disminuirVelocidad(disminucion)
 * {
 *  enemySpeed = enemySpeed*disminucion
 * }
 * y otro para restablecerla
 *  private void restablecerVelocidad(disminucion)
 * {
 *  enemySpeed = enemySpeed/disminucion
 * }
 * y ponerlo en el OnEnable y el OnDisable del script de Mojado directamente*/