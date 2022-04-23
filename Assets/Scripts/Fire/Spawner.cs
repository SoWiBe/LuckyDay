using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] smokes;
    [SerializeField] private Transform[] points;

    private int rand;
    private int randPosition;
    private float timeBtwSpawns;
    [SerializeField] private int startTimeToSpawn;

    private void Start()
    {
        this.timeBtwSpawns = startTimeToSpawn;
    }
    void Update()
    {
        if(this.timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, smokes.Length);
            randPosition = Random.Range(0, points.Length);
            Instantiate(smokes[rand], points[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeToSpawn;
        } else
        {
            this.timeBtwSpawns -= Time.deltaTime;
        }
    }
}
