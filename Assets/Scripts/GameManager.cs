using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RSE_Player player;
    private int Turn;
    
    private void Start()
    {
        player.InvokeSpawn();
    }


}
