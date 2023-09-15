using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour, WASD.IPlayerActions
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

    private WASD player_Controls;


    public void OnFire(InputAction.CallbackContext context)
    {
        print("OnFire");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        print("OnLook");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        print("OnMove");
    }

    private void OnEnable()
    {
        if (player_Controls == null)
        {       
            player_Controls = new WASD();
            player_Controls.Player.SetCallbacks(this);
        }
        player_Controls.Enable();
    }
}
