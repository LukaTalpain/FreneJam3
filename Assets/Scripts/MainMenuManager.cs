using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
