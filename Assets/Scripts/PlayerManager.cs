using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public RSE_Player playerEvent;

    public GameObject playerPrefab;
    public GameObject spawnPoint;

    private void OnEnable()
    {
        playerEvent.Spawn += SpawnPlayer;
    }
    private void OnDisable()
    {
        playerEvent.Spawn -= SpawnPlayer;
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.transform.position,Quaternion.Euler(0,45,0), this.transform);
    }
}
