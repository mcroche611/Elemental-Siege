using UnityEngine;

public class PhysicalAttack : MonoBehaviour
{

    [SerializeField]float coolDownSecs = 0.5f;

    [SerializeField] float attackFreeze = 0.25f;

    GameObject staffChild;
    float coolDown = 0; //se inicializa a 0 para que pueda atacar desde el principio

    private void Start()
    {
        staffChild = transform.GetChild(1).gameObject;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            staffChild.SetActive(true);
            staffChild.transform.position = transform.position;
            staffChild.transform.rotation = Rotation();
            Invoke("StaffDeactivate", 0.3f);
            GetComponent<PlayerController>().Knockback(attackFreeze);
            coolDown = coolDownSecs;
        }
        else coolDown -= Time.deltaTime;


    }

    private Quaternion Rotation()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vector = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);
        float angulo = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        return Quaternion.Euler(new Vector3(0f, 0f, angulo-90));
    }

    private void StaffDeactivate()
    {
        staffChild.SetActive(false);
    }
}


