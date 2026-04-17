using System;
using UnityEngine;


[CreateAssetMenu]
public class RSE_Player : ScriptableObject
{
    public event Action<int> Spawn;

    public event Action ObjectifDone;

    public void InvokeSpawn(int Turn)
    {
        Spawn?.Invoke(Turn);
    }
    public void InvokeObjectifDone ()
    {
        ObjectifDone?.Invoke();
    }
}
