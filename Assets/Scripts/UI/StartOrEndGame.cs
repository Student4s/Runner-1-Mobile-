using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartOrEndGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;
    [SerializeField] private Text txt;
    private bool isStart;

    public delegate void StartPlay();

    public static event StartPlay StartPlay1;
    private void Start()
    {
        isStart = true;
        Player.Dead += Death;
    }

    public void OnMouseDown()
    {
        if (isStart)
        {
            StartGame();
        }
        else
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        player.GetComponent<Player>().StartGame();
        isStart = false;
        button.SetActive(false);
        StartPlay1();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Death()
    {
        button.SetActive(true);
        txt.text = "Restart?";
    }

    private void OnDestroy()
    {
        Player.Dead -= Death;
    }
}
