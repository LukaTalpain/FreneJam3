using System;
using UnityEngine;


[CreateAssetMenu]
public class RSE_Player : ScriptableObject
{
    public event Action<int> Spawn;

    public event Action ObjectifDone;

    public event Action PlayerLost;
    public void InvokeSpawn(int Turn)
    {
        Spawn?.Invoke(Turn);
    }
    public void InvokeObjectifDone ()
    {
        ObjectifDone?.Invoke();
    }

    public void InvokePlayerLost()
    {
        PlayerLost?.Invoke();
    }
}
