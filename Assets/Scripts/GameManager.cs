using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RSE_Player player;
    private int Turn;
    public int MaxTurn;

    public SoTimer timer;

    public bool chronoOnOff;
    public bool ennemiObjectiveDone;
    private void OnEnable()
    {
        player.ObjectifDone += ObjectifDone;
    }
    private void OnDisable()
    {
        player.ObjectifDone -= ObjectifDone;
    }
    private void Start()
    {
        ennemiObjectiveDone = false;
        Turn = 0;
        timer.PlayerTime = true;
        timer.Timer = 0f;
        chronoOnOff = true;
        StartCoroutine(StartTimer(timer.MaxTime));
        player.InvokeSpawn(Turn);
        timer.turn = Turn;

    }

    private void ObjectifDone ()
    {
        if (Turn < MaxTurn)
        {
            if (timer.PlayerTime)
            {
                Turn++;
                chronoOnOff = false;
                timer.PlayerTime = !timer.PlayerTime;
                player.InvokeSpawn(Turn);
            }
            else
            {
                if (ennemiObjectiveDone)
                {
                    ennemiObjectiveDone = false;
                    Turn++;
                    chronoOnOff = false;
                    timer.PlayerTime = !timer.PlayerTime;
                    player.InvokeSpawn(Turn);
                }
                else
                {
                    player.InvokePlayerLost();
                }
            }
            
        }
        timer.turn = Turn;
    }

    IEnumerator StartTimer (float MaxTime)
    {
        yield return new WaitForSeconds(0.1f);
        print("time ++");
        timer.Timer += 0.1f;
        if (timer.Timer >= MaxTime)
        {
            timer.Timer = 0f;
            TimerEnded();
        }
        else
        {
            if (chronoOnOff)
            {
                StartCoroutine(StartTimer(MaxTime));
            }
            else
            {
                timer.Timer = 0f;
                chronoOnOff = true;
                StartCoroutine (StartTimer(MaxTime));
            }
        }
        
    }

    private void TimerEnded ()
    {
        if (!timer.PlayerTime)
        {
            print("objectif de l'ennemi accompli");
            ennemiObjectiveDone = true;
            player.InvokeObjectifDone();
            StartCoroutine(StartTimer(timer.MaxTime));
        }
        else
        {
            print("lost");
            player.InvokePlayerLost();
        }
    }
}
