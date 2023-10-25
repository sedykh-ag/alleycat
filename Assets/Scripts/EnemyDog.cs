using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    [SerializeField] GameObject[] anchors;

    public float MoveDuration;
    public float SpawnInterval;

    float timer = 0f;
    IEnumerator Run()
    {
        float timeSinceStarted = 0f;
        while (timeSinceStarted < MoveDuration)
        {
            transform.position = Vector3.Lerp(anchors[0].transform.position, anchors[1].transform.position, timeSinceStarted / MoveDuration);
            timeSinceStarted += Time.deltaTime;
            yield return null;
        }

        transform.position = anchors[0].transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > SpawnInterval)
        {
            StartCoroutine(Run());
            timer = 0f;
        }
    }
}
