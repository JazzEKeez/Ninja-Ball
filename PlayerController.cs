using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float rotationSpeed = 200.0f;
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private bool isAirBorne;
    
    public GameObject kunaiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAirBorne = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Get Axis for Arrow Key Input
        horizontalInput = Input.GetAxis("Horizontal");

        //Horizontal Inputs roll the Ninja Ball when it is on the ground
        if(isAirBorne == false)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
        else
        {
            transform.Rotate(Vector3.back * Time.deltaTime * horizontalInput * rotationSpeed);
        }
        
        //Space Bar throws a Kunai
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(kunaiPrefab, transform.position, transform.rotation);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isAirBorne = false;
        }
        else
        {
            isAirBorne = true;
        }
    }
}
