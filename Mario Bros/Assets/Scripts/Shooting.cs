using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePosition;
    public GameObject bullet;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Instantiate(bullet, firePosition.position, firePosition.rotation);
        }
    }
}
