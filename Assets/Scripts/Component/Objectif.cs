using UnityEngine;

public class Objectif : MonoBehaviour
{
    [SerializeField] private RSE_Player playerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.gameObject.GetComponent<Actor>().IsMainPlayer)
            {
                playerEvent.InvokeObjectifDone();
            }
        }
    }
}
