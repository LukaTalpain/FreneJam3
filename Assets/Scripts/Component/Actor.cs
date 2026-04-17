using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private PlayerAction action;
    [SerializeField] private Camera itsCamera;
    private Vector3 spawnPos;
    public bool IsPlayer;
    public bool IsMainPlayer;
    private void Start()
    {
        spawnPos = transform.position;
        if (!IsPlayer)
        {
            action.enabled = false;
            itsCamera.enabled = false;
            
        }
        else
        {
            action.enabled = true;
            itsCamera.enabled = true;
        }
        
    }

    public void Alive ()
    {
        action.enabled = true;
        itsCamera.enabled = true;
    }
}
