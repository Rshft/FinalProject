using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementSM : StateMachine
{
    public float speed = 12f;
    public Rigidbody rigidbody;
    public MeshRenderer meshRenderer;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
    }
    void ClampBoundary()
    {
        // Get camera reference (assuming the main camera)
        Camera cam = Camera.main;

        // Calculate camera boundaries based on its size and position
        float cameraHeight = 2f * cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        // Define the boundaries based on the camera's position and size
        float xMin = cam.transform.position.x - cameraWidth / 2;
        float xMax = cam.transform.position.x + cameraWidth / 2;
        float zMin = cam.transform.position.z - cameraHeight / 2;
        float zMax = cam.transform.position.z + cameraHeight / 2;

        // Clamp the player's position within the camera's boundaries
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        pos.z = Mathf.Clamp(pos.z, zMin, zMax);
        transform.position = pos;
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
    
}