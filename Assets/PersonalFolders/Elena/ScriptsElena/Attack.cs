using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //hacemos una variable de cooldown visible desde el editor de momento. Pasar a privado después
    public int cooldown = 2;
    public GameObject espada;
    public float alcance = 1.5f;
    void Start()
    {


    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && cooldown >=2)
        {
            
            Instantiate<GameObject>(espada, transform.position, Rotation(), transform); 
        }
    }
    //idea hacer que vaya al punto donde clickee el ratón y luego eliminarlo al poco
    private Quaternion Rotation()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vector = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);
        float angulo = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        return Quaternion.Euler(new Vector3(0f, 0f, angulo-90));
    }

}
