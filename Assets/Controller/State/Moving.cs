using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    private MovementSM stateMachine;

    // Boundary untuk kamera
    private float minX = -17f, maxX = 17f; // Batas horizontal (sumbu X)
    private float minZ = -10f, maxZ = 10f;   // Batas vertikal (sumbu Z)

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Moving State");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Input WASD
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D -> Sumbu X
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S -> Sumbu Z

        if (moveX == 0 && moveZ == 0)
        {
            // Jika tidak ada input, kembali ke Idle
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Pergerakan berdasarkan input
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S

        // Gerakan pada sumbu X dan Z
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * stateMachine.speed;

        // Gunakan MovePosition jika isKinematic = true
        stateMachine.rigidbody.MovePosition(stateMachine.transform.position + movement * Time.deltaTime);

        // Batasi posisi kamera atau karakter
        Vector3 clampedPosition = stateMachine.transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);

        // Terapkan posisi yang sudah dibatasi
        stateMachine.transform.position = clampedPosition;
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exited Moving State");
    }
}
