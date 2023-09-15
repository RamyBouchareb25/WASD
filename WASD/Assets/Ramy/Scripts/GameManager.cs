using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void showCursor(bool show)
    {
        Cursor.lockState = show ?  CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = show;
    }

    private void Awake()
    {
        showCursor(false);   
    }

    
}
