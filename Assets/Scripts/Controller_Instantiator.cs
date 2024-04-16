using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject instantiatePos;
    public float respawningTimer;
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

        if (respawningTimer <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }
}
