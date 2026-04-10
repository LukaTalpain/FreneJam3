using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private RSE_Input eventInput;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            eventInput.InvokeZpressed();
        }
        if (Input.GetKey(KeyCode.A))
        {
            eventInput.InvokeQpressed();
        }
        if (Input.GetKey(KeyCode.S))
        {
            eventInput.InvokeSpressed();
        }
        if (Input.GetKey(KeyCode.D))
        {
            eventInput.InvokeDpressed();
        }
    }
}
