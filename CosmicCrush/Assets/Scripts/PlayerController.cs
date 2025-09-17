using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count = 0;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnMove (InputValue momentValue)
    {
        Vector2 movementVector = momentValue.Get<Vector2>(); 
        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 26)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame

}
