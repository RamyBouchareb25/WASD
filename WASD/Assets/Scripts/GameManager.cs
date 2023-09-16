using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private Canvas _canvas;
    private SpriteBuilding _spriteBuilding;
    

   

    public void ShowCursor(bool dontShow)
    {
        Cursor.lockState = dontShow ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = dontShow;
        Time.timeScale = isPaused ? 0 : 1;
        _canvas.gameObject.SetActive(isPaused);
        isPaused = !isPaused;
        _spriteBuilding = GetComponent<SpriteBuilding>();
    }

  
    private void Awake()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _canvas.gameObject.SetActive(false);
        ShowCursor(false);
    }




    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _spriteBuilding.newLineM();
        }
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


    public void OnPause(InputAction.CallbackContext context)
    {
        var pressed = context.performed;
        if (!pressed) return;
        print("isPaused " + isPaused);
        ShowCursor(isPaused);
    }

    private void Update()
    {

        // var pause = player_Controls.Player.Pause.ReadValue<bool>();
        // print(pause);
    }

  
}
