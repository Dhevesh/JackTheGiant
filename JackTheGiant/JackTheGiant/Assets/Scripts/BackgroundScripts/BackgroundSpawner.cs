using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    private Vector3 lastPos;
    private float offSet = 8;
    [SerializeField]
    private GameObject background;
    public List<GameObject> backGroundCollector = new List<GameObject>(); // collect backgrounds into a list to destroy

    public void StartSpawning()
    {
        InvokeRepeating("SpawnBackground", 1f, 0.5f);
    }
    void SpawnBackground()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos = new Vector3(lastPos.x, lastPos.y - offSet, lastPos.z);
        GameObject bg = Instantiate(background, spawnPos, Quaternion.identity);
        lastPos = bg.transform.position;
    }

}
