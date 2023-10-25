using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ClothHang : MonoBehaviour
{
    private Collider2D _collider;
    private GameObject _player;
    private CatScript _playerScript;
    private Rigidbody2D _playerRb;
    private bool _playerHanged;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
         _player = GameObject.FindGameObjectWithTag("Player");
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerScript = _player.GetComponent<CatScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
            _playerRb.bodyType = RigidbodyType2D.Static;
            _playerHanged = true;
        }
    }

    private void Update()
    {
        if (_playerHanged && Input.GetAxisRaw("Vertical") < 0f) // jump down
        {
            _playerHanged = false;
            _playerRb.bodyType = RigidbodyType2D.Dynamic;

            _collider.enabled = false;
            StartCoroutine(EnableCollider());

            _player.transform.SetParent(null);
        }

        if (_playerHanged && Input.GetAxisRaw("Vertical") > 0f) // jump up
        {
            _playerHanged = false;
            _playerRb.bodyType = RigidbodyType2D.Dynamic;

            _collider.enabled = false;
            StartCoroutine(EnableCollider());

            _player.transform.SetParent(null);
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _playerScript.JumpSpeed);
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }
}
