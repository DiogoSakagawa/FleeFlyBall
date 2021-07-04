using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool onPlayer;

    public bool inField;

    private Rigidbody _rigidbody;

    private GameObject _currentPlayer;
    private GameObject _lastPlayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ControleFisica();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            print("tocou no ch�o");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InField"))
        {
            inField = false;
            print("Fora da Quadra");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InField"))
        {
            inField = true;
            print("Dentro da Quadra");
        }
    }

    public void AttachOnPlayer(GameObject newPlayer)
    {
        _lastPlayer = _currentPlayer;

        _currentPlayer = newPlayer;

        onPlayer = true;
    }

    public void Chutar(Vector3 force, ForceMode forceMode)
    {
        onPlayer = false;
        _rigidbody.AddForce(force, forceMode);
    }

    public void ControleFisica()
    {
        if (!onPlayer)
        {
            _rigidbody.isKinematic = false;
        }
        else
        {
            _rigidbody.isKinematic = true;

        }
    }
}
