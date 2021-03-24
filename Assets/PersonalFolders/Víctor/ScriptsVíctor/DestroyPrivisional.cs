using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrivisional : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
