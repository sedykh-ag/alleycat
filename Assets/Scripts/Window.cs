using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] spriteStates;

    private Collider2D col;

    public float OpenPeriodMin;
    public float OpenPeriodMax;
    private float OpenPeriod;
    public float OpenTime;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        OpenPeriod = Random.Range(OpenPeriodMin, OpenPeriodMax);
        spriteRenderer.sprite = spriteStates[0];
    }

    IEnumerator OpenWindow(float time)
    {
        spriteRenderer.sprite = spriteStates[1];
        col.enabled = true;

        yield return new WaitForSeconds(time);

        spriteRenderer.sprite = spriteStates[0];
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > OpenPeriod) 
        {
            StartCoroutine(OpenWindow(OpenTime));
            timer = 0f;
            OpenPeriod = Random.Range(OpenPeriodMin, OpenPeriodMax);
        }
    }
}
