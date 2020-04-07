using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Tilemap theMap;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        // this is setting target to whatever the instance of player controller is set to, having it in Start is so it finds the player whenever a new scene is called.
        target = PlayerController.instance.transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        // assigning the map bounds to the min and max paramaters.
        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    // LateUpdate is called once per frame after update
    // (this keeps the camera and movement in sync)
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Keep camera inside bounds.
        // Mathf is ia unity function and clamp is used to bind.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
 