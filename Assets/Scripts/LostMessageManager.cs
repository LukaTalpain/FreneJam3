using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMessageManager : MonoBehaviour
{
    public RSE_Player player;
    public SoTimer timer;
    public GameObject lostMessage;
    public TextMeshProUGUI nbrOfTurnText;
    public Camera Lostcamera;

    private void OnEnable()
    {
        player.PlayerLost += Lost;
    }
    private void OnDisable()
    {
        player.PlayerLost -= Lost;
    }


    private void Start()
    {
        Time.timeScale = 1;
        Lostcamera.enabled = false;
        lostMessage.SetActive(false);
    }
    private void Lost()
    {
        Time.timeScale = 0;
        Lostcamera.enabled = true;
        nbrOfTurnText.text = "Turn survived : " + timer.turn;
        lostMessage.SetActive(true);
    }



    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void RetryButton ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }
}
