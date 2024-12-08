using UnityEngine;

public class Idle : BaseState
{
    private MovementSM stateMachine;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Idle State");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Deteksi input WASD
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S

        if (moveX != 0 || moveZ != 0)
        {
            // Pindah ke Moving jika ada input
            stateMachine.ChangeState(stateMachine.movingState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exited Idle State");
    }
}
