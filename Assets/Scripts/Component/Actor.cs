using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private PlayerAction action;
    [SerializeField] private Camera itsCamera;
    private Vector3 spawnPos;
    public bool IsPlayer;
    public bool IsMainPlayer;

    public RSE_Player playerEvent;

    private void OnEnable()
    {
        playerEvent.ObjectifDone += ResetItSelf;
    }

    private void OnDisable()
    {
        playerEvent.ObjectifDone -= ResetItSelf;
    }


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

    private void ResetItSelf()
    {
        action.enabled = false;
        itsCamera.enabled = false;
        transform.position = spawnPos;
    }
}
