using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed in the Inspector

    void Update()
    {
        // Get input from the horizontal axis (A/D keys or Left/Right arrows)
        float move = Input.GetAxis("Horizontal");

        // Move the player left or right
        transform.position += new Vector3(move * speed * Time.deltaTime, 0, 0);
    }
}
