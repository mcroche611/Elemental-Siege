﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOnDestroy : MonoBehaviour
{
    GameObject slime;
    private void OnDestroy()
    {
        Instantiate<GameObject>(slime, transform.position, transform.rotation);
        Instantiate<GameObject>(slime, transform.position, transform.rotation);
        Instantiate<GameObject>(slime, transform.position, transform.rotation);
        Instantiate<GameObject>(slime, transform.position, transform.rotation);
    }
}

