using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform; //find the prefab with the tag "player"
    }

    //Update Function that gets called after Perry's position is rendered so that the camera can follow Perry's movement
    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x); //camera only moves right, never left
        transform.position = cameraPosition;
    }
}
