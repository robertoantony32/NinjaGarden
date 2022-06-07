using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnEnemies[] spawns;
    [SerializeField] private float startTime = 2f;
    [SerializeField] private float spawnTime = 6f;
    [SerializeField] private int maxSpawn = 3;


     private void Awake() 
    {
        InvokeRepeating("ChooseSpawn", startTime, spawnTime);    
    }

    private void ChooseSpawn(){
        var timesToSpawn = Random.Range(1, maxSpawn + 1);
        int lastSpawn = 0;

        for (int i = 0; i < timesToSpawn; i++)
        {
            var choosenIndex = (int) Random.Range(0, spawns.Length);

            if (i == 0) 
            {
                lastSpawn = choosenIndex;
            }
            else
            {
                if (lastSpawn == choosenIndex)
                {
                    choosenIndex += choosenIndex != spawns.Length - 1? 1 : -1;
                }
            }

            spawns[choosenIndex].Spawn();
        }
    }
}
