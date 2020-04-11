﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_WindowsAntoine : MonoBehaviour
{
    public GameObject taskManager;
    public KeyCode[] taskManagerKeys;
    private int keyNumberActual = 0;

    public float timeToNextKey;
    private float timeToNextKeyActual;
    private bool isOpenning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenning == true)
        {
            timeToNextKeyActual += Time.deltaTime;

            if (timeToNextKeyActual >= timeToNextKey)
            {
                timeToNextKeyActual = 0;
                keyNumberActual = 0;
                isOpenning = false;
            }
        }

        if (Input.GetKeyDown(taskManagerKeys[keyNumberActual]))
        {
            timeToNextKeyActual = 0;
            isOpenning = true;

            keyNumberActual ++;

            if (keyNumberActual >= taskManagerKeys.Length)
            {
                taskManager.SetActive(true);
            }
        }
    }
}