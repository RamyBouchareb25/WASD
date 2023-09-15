using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteBuilding : MonoBehaviour
{
    private void Update()
    {
        var pos = Mouse.current.position.ReadValue();
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;
        print(pos);
    }
}
