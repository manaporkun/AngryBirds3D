using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private Camera camera;
    private Rigidbody ballRigidbody;
    private Camera cam;
    private Vector2 mousePos;
    [SerializeField] private GameObject spring;
    private SpringJoint _springJoint;

    private void Start()
    {
        mousePos = new Vector2();
        cam = Camera.main;
        ballRigidbody = Ball.GetComponent<Rigidbody>();
        _springJoint = spring.GetComponent<SpringJoint>();
    }

   
    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var movement = new Vector3(horizontal, 0f, 0f);
        spring.transform.Translate(movement * 0.05f);

    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event   currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        
        var mouseClick = Input.GetMouseButton(0);
        
        if (mouseClick)
        {
            
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            point.z = -6.25f;
            ballRigidbody.MovePosition(point);
        }

        if (Input.GetMouseButtonUp(0))
        {
            spring.SetActive(false);
        }

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
}
