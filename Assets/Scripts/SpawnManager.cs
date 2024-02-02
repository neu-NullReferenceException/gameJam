using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float SpawnChance;
    public bool spawnHouse;
    public GameObject HousePrefab;
    public List<GameObject> Houses;

    void Start()
    {
        StaticTicker.Register(Tick);
    }

    public void Tick() 
    {
        if (StaticTicker.tickCount == 1) 
        {
            spawnHouse = true;
        }
        if (StaticTicker.tickCount == 31)
        {
            spawnHouse = true;
        }
    }

    void Update()
    {
        if (spawnHouse) 
        {
            Debug.Log("Spawning house");
            int xCoord = UnityEngine.Random.Range(-5000,5000);
            int yCoord = UnityEngine.Random.Range(-5000,5000);
            float sample = Mathf.PerlinNoise(xCoord, yCoord);
            if (sample < SpawnChance)
            {
                Debug.Log(sample);
                float xCoordf = xCoord / 100f;
                float yCoordf = yCoord / 100f;
                GameObject house = Instantiate(HousePrefab);
                house.transform.position = new Vector3(xCoordf, 0, yCoordf);
                house.gameObject.SetActive(true);
                Houses.Add(house);
                spawnHouse = false;
            }
        }
    }
}
