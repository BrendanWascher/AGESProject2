using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    public static float gameTime = 0.0f;
    public static float holdTime;
     
    private bool isGamePlaying = false;

    private static GameTimer instance = null;

    public static GameTimer Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);

            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        if(isGamePlaying)
        {
            UpdateTime();
        }
        UpdateLevel();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        holdTime = (Mathf.Round(gameTime * 10f) / 10f);
        if(holdTime < 10)
        {
            timeText.text = "00" + holdTime.ToString();
        }
        else if(holdTime < 100)
        {
            timeText.text = "0" + holdTime.ToString();
        }
        else if(holdTime>=1000)
        {
            timeText.text = "999.9";
            gameTime = 999.9f;
        }
        else
        {
            timeText.text = holdTime.ToString();
        }
    }

    private void UpdateLevel()
    {
        // Debug.Log(ExitDoor.levelNumber);
        if(ExitDoor.levelNumber != 0 && !isGamePlaying)
        {
            isGamePlaying = true;
        }
        if(ExitDoor.levelNumber > ExitDoor.totalLevels)
        {
            isGamePlaying = false;
            SelfDestruct();
            ExitDoor.levelNumber = 0;
        }
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
