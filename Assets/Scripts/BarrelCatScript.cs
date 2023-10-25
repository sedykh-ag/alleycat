using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BarrelScript : MonoBehaviour
{
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject[] anchors;

    public float MoveDuration;
    public float SpawnTimeMin;
    public float SpawnTimeMax;
    public float UpTime;

    private float timer = 0f;
    private int curAnchor = 0;
    private float SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = Random.Range(SpawnTimeMin, SpawnTimeMax);
    }
    
    IEnumerator MoveToAnchor(int anchor, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        float timeSinceStarted = 0f;

        Vector3 initPos = cat.transform.position;
        Vector3 endPos = anchors[anchor].transform.position;

        while (timeSinceStarted < MoveDuration)
        {
            cat.transform.position = Vector3.Lerp(initPos, endPos, timeSinceStarted / MoveDuration);
            timeSinceStarted += Time.deltaTime;
            yield return null;
        }

        cat.transform.position = endPos;

        var coll = barrel.GetComponent<Collider2D>();

        if (anchor == 0) // UpAnchor
            coll.enabled = false;
        else // DownAnchor
            coll.enabled = true;
    }

    void ToggleCat()
    {
        StartCoroutine(MoveToAnchor(0, 0)); // Up
        StartCoroutine(MoveToAnchor(1, UpTime + MoveDuration)); // Down
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > SpawnTime)
        {
            ToggleCat();

            timer = 0.0f;
            SpawnTime = Random.Range(SpawnTimeMin, SpawnTimeMax);
        }
    }
}
