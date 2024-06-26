﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false; 
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;

    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver) // Si el juego se acabo muestra los resultados en la pantalla 
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString();
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Time.deltaTime;
            distance = (float)(Math.Round(distance * 100.0f) * 0.01f);
            distanceText.text = distance.ToString();
        }
    }
}
