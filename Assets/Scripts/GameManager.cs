using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RSE_Player player;
    private int Turn;
    public int MaxTurn;

    private void OnEnable()
    {
        player.ObjectifDone += ObjectifDone;
    }
    private void OnDisable()
    {
        player.ObjectifDone -= ObjectifDone;
    }
    private void Start()
    {
        Turn = 0;
        player.InvokeSpawn(Turn);
    }

    private void ObjectifDone ()
    {
        if (Turn < MaxTurn)
        {
            Turn++;
            player.InvokeSpawn(Turn);
        }
    }
}
