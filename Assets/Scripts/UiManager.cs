using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider timerSlider;
    public Image sprite;
    [SerializeField] private Color Team1Color;
    [SerializeField] private Color Team2Color;
    [SerializeField] private TextMeshProUGUI turnText;
    public SoTimer timer;


    private void Update()
    {
        timerSlider.value = 1 - (timer.Timer / timer.MaxTime);
        if (timer.PlayerTime)
        {
            sprite.color = Team1Color;
        }
        else
        {
            sprite.color = Team2Color;
        }
        turnText.text = "Turn : " + timer.turn;
    }


}
