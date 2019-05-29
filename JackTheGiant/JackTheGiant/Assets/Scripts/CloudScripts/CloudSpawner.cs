using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] whiteClouds;
    [SerializeField]
    private GameObject darkCloud;

    private float distanceBetweenClouds = 3f;

    private float minX;
    private float maxX;

    private float lastCloudPositionY = 0;
    private float newCloudPositionY = 0;

    private float controlX;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    void FixedUpdate()
    {
        CreateClouds();
    }
    void Awake()
    {
        controlX = 0;
        SetMinMaxX();
    }

    void SetMinMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void CreateClouds()
    {
        int cloudIndex = Random.Range(0, whiteClouds.Length);
        int cloudProbability = Random.Range(0, 100);
        GameObject getCloud;
        Vector3 temp = whiteClouds[cloudIndex].transform.position;
        temp.y = newCloudPositionY;
        switch (controlX)
        {
            case 0:
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
                break;
            case 1:
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
                break;
            case 2:
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
                break;
            case 3:
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
                break;
        }

        if (cloudProbability < 10)
            getCloud = darkCloud;
        else
            getCloud = whiteClouds[cloudIndex];
        getCloud.transform.position = temp;
        GameObject spawnedClouds = Instantiate(getCloud);
        lastCloudPositionY = getCloud.transform.position.y;
        newCloudPositionY = lastCloudPositionY - distanceBetweenClouds;
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "WhiteCloud")
        {
            lastCloudPositionY = target.transform.position.y;
            CreateClouds();
        }
    }

}
