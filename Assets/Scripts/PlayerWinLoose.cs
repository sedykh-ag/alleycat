using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinLoose : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [SerializeField] private GameObject YouLostText;
    [SerializeField] private GameObject YouWonText;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Window"))
        {
            Win();
        }
        else if (other.gameObject.CompareTag("Dog"))
        {
            Loose();
        }
    }
    private void Loose()
    {
        Debug.Log("Player lost!");
        YouLostText.SetActive(true);
        rb.bodyType = RigidbodyType2D.Static;
        spriteRenderer.sprite = null;
        StartCoroutine(RestartLevel(3f));
    }
    private void Win()
    {
        Debug.Log("Player won!");
        YouWonText.SetActive(true);
        rb.bodyType = RigidbodyType2D.Static;
        spriteRenderer.sprite = null;
        StartCoroutine(RestartLevel(3f));
    }
    IEnumerator RestartLevel(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
