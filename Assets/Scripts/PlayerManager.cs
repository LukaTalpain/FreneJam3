using UnityEngine;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour
{
    public RSE_Player playerEvent;

    public GameObject playerOriginalPrefab;
    public GameObject playerPrefab;
    public List<GameObject> spawnPoint;


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
            GameObject _Instance =  Instantiate(playerOriginalPrefab, new Vector3(spawnPoint[0].transform.position.x, spawnPoint[0].transform.position.y + 1, spawnPoint[0].transform.position.z), Quaternion.Euler(0, 45, 0), this.transform);
            _Instance.GetComponent<Actor>().IsMainPlayer = true;
        }
        else
        {
            GameObject _Instance = Instantiate(playerPrefab, new Vector3(spawnPoint[Turn].transform.position.x, spawnPoint[Turn].transform.position.y + 1, spawnPoint[Turn].transform.position.z), Quaternion.Euler(0, 45, 0), this.transform);
        }
        
    }
}
