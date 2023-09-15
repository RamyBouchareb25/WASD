using System;
using System.Collections;
using System.Collections.Generic;
using Ramy.Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteBuilding : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private GameObject _gameObject;
    private Camera _camera;
    private GameObject lineGameObject;
    private GameManager _gameManager = GameManager.Instance();
    private LineRenderer Line;
    [SerializeField] private float minDistance = 0.1f;
    private Vector3 previousPos;
    private bool newLine = true;
    [SerializeField] private CircleCollider2D SnappingPoint;

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
    }
    
    private void DrawLine()
    {
        var pos = Mouse.current.position.ReadValue();
        if (!Mouse.current.leftButton.isPressed) return;
        var worldPos = _camera.ScreenToWorldPoint(pos);
        var newPos = new Vector3(worldPos.x,worldPos.y,0);
        if (!(Vector3.Distance(newPos, previousPos) > minDistance)) return;
        var isInBounds = SnappingPoint.bounds.Contains(newPos);
        if (newLine && isInBounds)
        {
            var targetPos = SnappingPoint.transform.position;
            targetPos.z = 0;
            Line.SetPosition(0,targetPos);
            newLine = false;  
            
        } else if (previousPos == lineGameObject.transform.position || newLine)
        {
            Line.SetPosition(0,newPos);
            newLine = false;
        }
        var positionCount = Line.positionCount;
        positionCount++;
        Line.positionCount = positionCount;
        Line.SetPosition(positionCount -1, newPos);
        previousPos = newPos;
    }
    private void Update()
    {
        if (_gameManager.isPaused) return;
        DrawLine();
    }
}
