using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Camera's position should be the same as the car's
    [SerializeField] GameObject objectToFollow;

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + new Vector3 (0,0,-10);
    }
}
