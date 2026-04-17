using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public RSE_Player playerEvent;

    public GameObject playerPrefab;
    public GameObject spawnPoint;

    private GameObject LastPlayerSpawned;

    private void OnEnable()
    {
        playerEvent.Spawn += SpawnPlayer;
    }
    private void OnDisable()
    {
        playerEvent.Spawn -= SpawnPlayer;
    }

    private void SpawnPlayer(int Turn)
    {
        if (Turn == 0)
        {
            GameObject _Instance =  Instantiate(playerPrefab, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 1, spawnPoint.transform.position.z), Quaternion.Euler(0, 45, 0), this.transform);
            _Instance.GetComponent<Actor>().IsMainPlayer = true;
            LastPlayerSpawned = _Instance;
        }
        else
        {
            GameObject _Instance = Instantiate(playerPrefab, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 1, spawnPoint.transform.position.z), Quaternion.Euler(0, 45, 0), this.transform);
        }
        
    }
}
