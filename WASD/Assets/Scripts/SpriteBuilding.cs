using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ramy.Scripts;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.Utils; 
public class SpriteBuilding : MonoBehaviour
{
    
    private GameObject _gameObject;
    [SerializeField]private Camera _camera;
    private GameObject lineGameObject;
    private GameManager _gameManager = GameManager.Instance();
    private LineRenderer Line;
    [SerializeField] private float minDistance = 0.1f;
    private Vector3 previousPos;
    private bool newLine = true;
    private GameObject[] SnappingPoints;
    private GameObject currentSnapPoint,nextSnapPoint;
    [SerializeField]private GameObject start,end,humanBridge;
    [SerializeField] private Vector3 offset;
    [SerializeField]private Vector3 offsetBridge = new Vector3(0.9f,0.4f,0);
    private Vector3 startPosition;
    [SerializeField] private MinionOrganiser orgnizer;
    private void Awake()
    {
        SnappingPoints = GameObject.FindGameObjectsWithTag("Snap");
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

    private void SpawnBridge(Vector3 Start,Vector3 End)
    {
        var startClone = Instantiate(start,Start,quaternion.identity);
        var endClone = Instantiate(end, End, Quaternion.identity);
        var exBridge = Instantiate(humanBridge, Start + offset, Quaternion.identity);
        exBridge.GetComponent<HingeJoint2D>().connectedBody = startClone.GetComponent<Rigidbody2D>();
        Vector3 directionToEnd = (endClone.transform.position - startClone.transform.position).normalized;
        float distance = (endClone.transform.position - startClone.transform.position).magnitude;
        print(distance);
        int peopleCount = Mathf.CeilToInt(distance);
        var position = endClone.transform.position;
        var position2 = startClone.transform.position;
        var position1 = position2;
        var angle = UtilsClass.GetAngleFromVectorFloat(new Vector3(position.x - position1.x,position.y - position1.y,0));
        exBridge.transform.rotation = quaternion.Euler(0,0,-angle);
        var firstBridge = exBridge;
        var buildable = orgnizer.DeleteMinion(peopleCount - 1);

        //var canBuild = orgnizer.Buildable();
        if (buildable)
        {
            for (var i = 0; i < peopleCount - 1; i++)
            {

                Vector3 newPosition = position2 + directionToEnd * (i + offsetBridge.x);
                var newBridge = Instantiate(humanBridge, newPosition, quaternion.identity);
                newBridge.GetComponent<HingeJoint2D>().connectedBody = i == 0 ? startClone.GetComponent<Rigidbody2D>() : exBridge.GetComponent<Rigidbody2D>();
                newBridge.transform.rotation = Quaternion.Euler(0, 0, angle);
                exBridge = newBridge;
            }

            endClone.GetComponent<HingeJoint2D>().connectedBody = exBridge.GetComponent<Rigidbody2D>();
        }
        Destroy(firstBridge);

    }
    private void DrawLine()
    {
        var pos = Mouse.current.position.ReadValue();
        var worldPos = _camera.ScreenToWorldPoint(pos);
        worldPos.z = 0;
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (!newLine)
            {
                var contains = false;
                foreach (var snap in SnappingPoints)
                {
                    if (snap.name == currentSnapPoint.name) continue;
                    contains = contains ||  snap.GetComponent<BoxCollider2D>().bounds.Contains(worldPos);
                    if (!snap.GetComponent<BoxCollider2D>().bounds.Contains(worldPos)) continue;
                    print("is in right position : "+ snap.GetComponent<BoxCollider2D>().bounds.Contains(worldPos)+"\n snapPoint : "+snap);
                    nextSnapPoint = snap;
                }
                print("NextSnapPoint : "+nextSnapPoint);
                print("current snapPoint : " + currentSnapPoint);
                if (contains)
                {
                    SpawnBridge(startPosition, worldPos);
                    print("Attach");
                }
                Line.positionCount = 1;
                newLine = true;
            }
        }
        
        if (!Mouse.current.leftButton.isPressed) return;
        if (!(Vector3.Distance(worldPos, previousPos) > minDistance)) return;
        var isInBounds = false;
        foreach (var snap in SnappingPoints)
        {
            isInBounds = isInBounds || snap.GetComponent<BoxCollider2D>().bounds.Contains(worldPos);
            if (!snap.GetComponent<BoxCollider2D>().bounds.Contains(worldPos) || !newLine) continue;
            currentSnapPoint = snap;
            startPosition = worldPos;
            print("current snap : "+currentSnapPoint);

        }
        if (previousPos == lineGameObject.transform.position || newLine)
        {
            if (!isInBounds) return;
            Line.SetPosition(0,worldPos);
            newLine = false;
        }
        var positionCount = Line.positionCount; 
        positionCount++;
        Line.positionCount = positionCount;
        Line.SetPosition(positionCount -1, worldPos);
        previousPos = worldPos;
    }
    private void Update()
    {
        if (_gameManager.isPaused) return;
        DrawLine();

    }
}
