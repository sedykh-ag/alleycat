using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothHangerMoving : MonoBehaviour
{
    [SerializeField] private GameObject[] anchors;
    [SerializeField] private GameObject clothHanger;
    private int curAnchor = 0;
    private float timer = 0f;

    public float MoveDuration;
    public float MovePeriod;
    IEnumerator Move()
    {
        float timeSinceStarted = 0f;
        Vector3 initPos = clothHanger.transform.position;
        Vector3 endPos = anchors[curAnchor].transform.position;

        while (timeSinceStarted < MoveDuration) 
        {
            clothHanger.transform.position = Vector3.Lerp(initPos, endPos, timeSinceStarted / MoveDuration);
            timeSinceStarted += Time.deltaTime;
            yield return null;
        }

        clothHanger.transform.position = endPos;
        curAnchor = (curAnchor + 1) % anchors.Length;
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > MovePeriod)
        {
            StartCoroutine(Move());
            timer = 0f;
        }
    }

}
