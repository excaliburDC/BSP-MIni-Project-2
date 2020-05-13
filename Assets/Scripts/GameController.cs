using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : SingletonManager<GameController>
{
    public GameObject waveCountdownCanvas;
    public Text waveCountdownText;
    public bool waveStarted = false;


    private int timer = 5;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }







}
