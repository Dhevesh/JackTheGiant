using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "WhiteCloud" || target.tag == "DarkCloud")
        {
            target.gameObject.SetActive(false);
        }
    }
}
