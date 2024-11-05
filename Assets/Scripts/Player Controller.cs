using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float speed;         // How hard the ball is pushed
    private float xDirection;    // Move the ball left and right
    private float zDirection;    // Move the ball forward and backwards
    private int count;      //Counts the pick ups

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MoveBall();
    }
    private void MoveBall()
    {
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        GetComponent<Rigidbody>().AddForce(direction.normalized * speed);
    }
    // Listens for the player clicking arrows or W-A-S-D keys.
    private void GetPlayerInput()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");
    }

    private void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }
}
