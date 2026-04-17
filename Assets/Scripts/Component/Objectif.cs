using System.Collections;
using UnityEngine;

public class Objectif : MonoBehaviour
{
    [SerializeField] private RSE_Player playerEvent;
    private bool canTrigger;

    private void Start()
    {
        canTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.gameObject.GetComponent<Actor>().IsMainPlayer)
            {
                if (canTrigger)
                {
                    StartCoroutine(Cooldown()); 
                    playerEvent.InvokeObjectifDone();
                }
                
            }
        }
    }


    IEnumerator Cooldown ()
    {
        canTrigger = false;
        yield return new WaitForSeconds(1f);
        canTrigger = true;
    }
}
