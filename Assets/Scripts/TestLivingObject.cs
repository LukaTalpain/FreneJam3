using System;
using UnityEngine;

public class TestLivingObject : MonoBehaviour
{
    public MoveSystem MoveSystem;
    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Alive();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSystem.Move(DirectionType.Right);
        }
    }
    private void Start()
    {
        MoveSystem = this.gameObject.GetComponent<MoveSystem>();
        MoveSystem.enabled = false;
    }
    private void Alive()
    {
        if (MoveSystem.enabled == false)
        {
            MoveSystem.enabled = true;
        }
        else
        {
            MoveSystem.enabled = false;
        }
        
    }
}
