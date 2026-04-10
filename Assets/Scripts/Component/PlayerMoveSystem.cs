using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMoveSystem : MonoBehaviour
{
    public Vector3 directionVec = new Vector3(0,0,0);
    private Rigidbody rb;
    public float speed;
    private void Start()
    {
        directionVec = new Vector3(0, 0,0);
        rb = GetComponent<Rigidbody>();
    }
    public void Move (DirectionType direction)
    {
        if (direction == DirectionType.Forward)
        {
            directionVec.x += 1;
        }
        if (direction == DirectionType.Backward)
        {
            directionVec.x -= 1;
        }
        if (direction == DirectionType.Right)
        {
            directionVec.z += 1;
        }
        if (direction == DirectionType.Left)
        {
            directionVec.z -= 1;
        }
    }
    private void LateUpdate()
    {
        NormalizeVec();
        //faire le movement 
        rb.AddForce(directionVec* speed);


        directionVec = Vector3.zero;
        //remmetre le vec a 0
    }

    private void NormalizeVec ()
    {
        if (directionVec.x < -1)
        {
            directionVec.x = -1;
        }
        if (directionVec.x > 1)
        {
            directionVec.x = 1;
        }

        if (directionVec.z < -1)
        {
            directionVec.z = -1;
        }
        if (directionVec.z > 1)
        {
            directionVec.z = 1;
        }

        directionVec.Normalize();
    }
}
public enum DirectionType
{
    Forward, Backward, Right, Left
}
