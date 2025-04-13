using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobvement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) // Check if the left mouse button is pressed
        {
           float horizontal = Input.GetAxis("Mouse X"); 
           transform.Translate(UnityEngine.Vector3.right * horizontal * moveSpeed * Time.deltaTime); // Move the player horizontally based on mouse movement
        }
        
    }
}
