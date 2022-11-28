using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int _counter;
    private Rigidbody _rigidBody;
    [SerializeField] private float ballSpeed;
    [SerializeField] private Text counterText;
    [SerializeField] private Text winText;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _counter = 0;
        SetCounterText();
        winText.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f, moveVertical);

        _rigidBody.AddForce(movement * ballSpeed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _counter = _counter + 1;
            SetCounterText();
        }
    }
    void SetCounterText()
    {
        counterText.text = "Count : " + _counter.ToString();
        if (_counter >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
