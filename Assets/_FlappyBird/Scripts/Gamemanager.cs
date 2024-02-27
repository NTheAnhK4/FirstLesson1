using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public float cooldown;
    public float spawnTime = 5f;

    private void Start()
    {
        cooldown = spawnTime;
    }

    void SpawnWall()
    {
        PoolingManager.Instance.GetObject(NamePrefabPool.Wall, position: new Vector3(5f, 0f, 0f)).Disable(10f);
    }
    private void Update()
    {
        if (cooldown <= 0)
        {   
            SpawnWall();
            cooldown = spawnTime;
        }

        else 
            cooldown -= Time.deltaTime;
    }
}
