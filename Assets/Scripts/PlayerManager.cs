using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMoveSystem moveSystem;
    [SerializeField] private RSE_Input _Input;

    private void OnEnable()
    {
        _Input.Zpressed += MoveForward;
        _Input.Spressed += MoveBackward;

        _Input.Dpressed += MoveRight;
        _Input.Qpressed += MoveLeft;
    }

    private void OnDisable()
    {
        _Input.Zpressed -= MoveForward;
        _Input.Spressed -= MoveBackward;

        _Input.Dpressed -= MoveRight;
        _Input.Qpressed -= MoveLeft;
    }

    private void MoveForward ()
    {
        moveSystem.Move(DirectionType.Forward);
    }
    private void MoveBackward()
    {
        moveSystem.Move(DirectionType.Backward);
    }
    private void MoveRight()
    {
        moveSystem.Move(DirectionType.Right);
    }
    private void MoveLeft()
    {
        moveSystem.Move(DirectionType.Left);
    }

}
