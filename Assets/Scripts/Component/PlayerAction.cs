using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private MoveSystem moveSystem;
    [SerializeField] private RSE_Input _Input;
    private Camera _camera;
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
    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootToTransform();
        }
    }
    private void ShootToTransform ()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    }
}
