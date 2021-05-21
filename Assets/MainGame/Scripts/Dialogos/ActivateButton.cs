using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    [SerializeField]
    GameObject startButton;

    public void SetActiveButton()
    {
        startButton.SetActive(true);
    }
}
