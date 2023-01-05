using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // fields for determining the color of the car based upon whether
    // a package has been picked up or not
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    // represents delay between package disappearing and driving over it
    [SerializeField] float destroyDelay = 0.5f;

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // text printed to console whenever the car collides with a
        // non-package or customer object
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // if the object is a package, print text to console to confirm,
        // set hasPackage equal to true, change the car color, and
        // destroy the object so that it disappears from the screen
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package collected");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        } 
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false; // set to false so a new package can be picked up
            spriteRenderer.color = noPackageColor;
        }
    }
}
