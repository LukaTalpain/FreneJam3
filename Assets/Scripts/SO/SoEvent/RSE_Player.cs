using System;
using UnityEngine;


[CreateAssetMenu]
public class RSE_Player : ScriptableObject
{
    public event Action Spawn;


    public void InvokeSpawn()
    {
        Spawn?.Invoke();
    }

}
