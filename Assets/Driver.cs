using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;

    // fields representing movement speed after car drives over
    // speed boost or bump
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void Update()
    {
        // function is called once per frame
        // allows car to be driven forward/backward and steered toward the left or right
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // when car drives over Boost-tagged object, moveSpeed increases,
        // else when car drives over Bump-tagged object, moveSpeed decreases
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
        else if (other.tag == "Bump")
        {
            moveSpeed = slowSpeed;
        }
    }
}
