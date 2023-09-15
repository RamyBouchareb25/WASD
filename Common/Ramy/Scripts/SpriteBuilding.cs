using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteBuilding : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private GameObject _gameObject;
    private Camera _camera;
    private GameObject lineGameObject;
    private LineRenderer Line;
    [SerializeField] private float minDistance = 0.1f;
    private Vector3 previousPos;
    private bool newLine = true;
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        _gameObject = new GameObject();
        var spriteRenderer = _gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = _sprite;
        lineGameObject = GameObject.Find("Line");
        Line = lineGameObject.GetComponent<LineRenderer>();
        previousPos = lineGameObject.transform.position;
        Line.positionCount = 1;
    }

    public void newLineM()
    {
        Line.positionCount = 1;
        newLine = true;
        print("released :" +newLine);
    }
    private void Update()
    {
        
        var pos = Mouse.current.position.ReadValue();
        if (!Mouse.current.leftButton.isPressed) return;
        var worldPos = _camera.ScreenToWorldPoint(pos);
        var worldPos2 = new Vector3(worldPos.x,worldPos.y,0);
        if (!(Vector3.Distance(worldPos2, previousPos) > minDistance)) return;
        if (previousPos == lineGameObject.transform.position || newLine)
        {
            Line.SetPosition(0,worldPos2);
            newLine = false;
        }
        var positionCount = Line.positionCount;
        positionCount++;
        Line.positionCount = positionCount;
        Line.SetPosition(positionCount -1, worldPos2);
        previousPos = worldPos2;
        //Instantiate(_gameObject,worldPos2,quaternion.identity);
        
    }
}
