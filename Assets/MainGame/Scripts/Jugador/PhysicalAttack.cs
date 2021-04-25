using UnityEngine;

public class PhysicalAttack : MonoBehaviour
{

    [SerializeField]float cooldownSecs = 0.5f;

    [SerializeField] float staffDuration = 0.25f;

    GameObject staffChild;
    float cooldown = 0; //se inicializa a 0 para que pueda atacar desde el principio
    Rigidbody2D playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        staffChild = transform.GetChild(1).gameObject;

    }
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            Freeze();
            staffChild.SetActive(true);
            staffChild.transform.position = transform.position;
            staffChild.transform.rotation = Rotation();
            Invoke("StaffDeactivate", staffDuration);
            Invoke("Unfreeze", cooldownSecs);  
            cooldown = cooldownSecs;
        }

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
    private void Unfreeze()
    {
        playerRigidbody.constraints = RigidbodyConstraints2D.None;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
    private void Freeze()
    {
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

    }

}


