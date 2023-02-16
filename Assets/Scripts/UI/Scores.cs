using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] private Text txt;
    private int scores = 0;
    private bool isLive = false;

    private void Start()
    {
        Player.Dead += PlayerDeath;
        StartOrEndGame.StartPlay1 += StartPlay;
    }

    void FixedUpdate()
    {
        if (isLive)
        {
            scores += 1;
        }

        txt.text = "" + scores;
    }

    void PlayerDeath()
    {
        isLive = false;
    }

    void StartPlay()
    {
        isLive = true;
    }
    private void OnDestroy()
    {
        Player.Dead -= PlayerDeath;
        StartOrEndGame.StartPlay1 -= StartPlay;
    }
}
