using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.2f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
            moveSpeed = slowSpeed;
            Debug.Log("whambam");

    }
    private void OnTriggerEnter2D(Collider2D other){
         if(other.tag == "boost"){
            moveSpeed = boostSpeed;
            Debug.Log("Speed!!!");
        }
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if(speedAmount < 0){
            steerAmount = -steerAmount;
            speedAmount = speedAmount*0.5f;
        }

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
    }
}
