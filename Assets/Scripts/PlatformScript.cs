using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Collider2D _collider;
    private bool _playerOnPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerOnPlatform = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerOnPlatform && Input.GetAxisRaw("Vertical") < 0f) 
        {
            _collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }

}
