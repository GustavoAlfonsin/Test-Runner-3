using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject powerUP;
    public GameObject instantiatePos;
    public float respawningTimer;
    public float timerPowerUps = 15;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2; //Establece la velocidad de los enemigos en 2
    }

    void Update()
    {
        SpawnEnemies();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies() // Funcion para hacer que aparescan enemigos en un intervalo de tiempo
    {
        respawningTimer -= Time.deltaTime;
        timerPowerUps -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            if (timerPowerUps <= 0)
            {
                Instantiate(powerUP, instantiatePos.transform);
                timerPowerUps = UnityEngine.Random.Range(2, 5) * 10;
                respawningTimer = 3;
            }
            else
            {
                Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
                respawningTimer = UnityEngine.Random.Range(2, 6);
            }
        }
    }
}
