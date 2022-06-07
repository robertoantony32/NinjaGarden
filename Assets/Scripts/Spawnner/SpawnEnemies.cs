using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    public void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
