using System;
using UnityEngine;

[CreateAssetMenu]
public class RSE_Input : ScriptableObject
{
    public event Action Zpressed;
    public event Action Qpressed;
    public event Action Spressed;
    public event Action Dpressed;


    public void InvokeZpressed ()
    {
        Zpressed?.Invoke();
    }

    public void InvokeQpressed()
    {
        Qpressed?.Invoke();
    }
    public void InvokeSpressed()
    {
        Spressed?.Invoke();
    }
    public void InvokeDpressed()
    {
        Dpressed?.Invoke();
    }
}
