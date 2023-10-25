using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
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
    }
    private void Win()
    {
        Debug.Log("Player won!");
        YouWonText.SetActive(true);
        rb.bodyType = RigidbodyType2D.Static;
        spriteRenderer.sprite = null;
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
