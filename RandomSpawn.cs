using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private float Ypos;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float spawnTime = 6.1f;
    private Vector3 spawnPosition;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        spawnPosition.x = Random.Range(-4, 30);
        spawnPosition.y = Ypos;
        spawnPosition.z = 0;
        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length)], spawnPosition, Quaternion.identity);
    }
}