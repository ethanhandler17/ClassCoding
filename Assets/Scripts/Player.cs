using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    //variables
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalUpperScreenLimit = 0.0f;
    private float verticalLowerScreenLimit = -3.5f;

    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpeed = 6.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();        
    }


    void Movement()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");
       //move the player
       transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
       //keep the player in bounds
       // if the player is out of bounds, moves them to the opposite side of the screen
       if(transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
       {
        transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
       }
       transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, verticalLowerScreenLimit, verticalUpperScreenLimit), 0);
       
    }
    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shooting");
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), bulletPrefab.transform.rotation);
        }
    }





}
