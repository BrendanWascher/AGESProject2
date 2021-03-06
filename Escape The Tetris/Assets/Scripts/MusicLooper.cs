﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    private static MusicLooper instance = null;

    public static MusicLooper Instance
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
        CheckSelfDestruct();
    }

    private void CheckSelfDestruct()
    {
        if (ExitDoor.levelNumber > ExitDoor.totalLevels)
        {
            Destroy(gameObject);
        }
    }

}
