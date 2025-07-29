using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoleClick : MonoBehaviour
{
    public static bool IsClicked = false;
    
    void OnMouseDown()
    {
        if (!IsClicked)
        {
            Debug.Log("Mole clicked");
            GameManager.Score += 20;
            IsClicked = true;
        }
    }
}