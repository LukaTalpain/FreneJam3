using UnityEditor.SceneManagement;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public Vector3 directionVec = new Vector3(0,0,0);
    private Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public float actualFloat;
    [SerializeField] private InputStorage storage;
    [SerializeField] private RSE_Player player;

    private void OnEnable()
    {
        player.ObjectifDone += ResetEverything;

    }
    private void OnDisable()
    {
        player.ObjectifDone -= ResetEverything;
    }

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
            directionVec.z -= 1;
        }
        if (direction == DirectionType.Left)
        {
            directionVec.z += 1;
        }
    }
    private void FixedUpdate()
    {
        NormalizeVec();
        storage.AddDirection(directionVec);
        directionVec += storage.GetDirection();
        NormalizeVec();
        //faire le movement 
        if (rb.linearVelocity.magnitude + speed> maxSpeed)
        {
            //rien
        }
        else
        {
            rb.linearVelocity += (directionVec * speed)/4;

        }
        if (rb.linearVelocity.magnitude <0.01)
        {
            rb.linearVelocity = new Vector3(0,0,0);
        }
        actualFloat = rb.linearVelocity.magnitude;
        
        directionVec = Vector3.zero;
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

    public void ResetEverything ()
    {
        rb.linearVelocity = Vector3.zero;
        directionVec = Vector3.zero;
    }



}
public enum DirectionType
{
    Forward, Backward, Right, Left
}








