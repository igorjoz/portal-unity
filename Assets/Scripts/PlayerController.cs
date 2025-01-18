using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f; //szybkość naszej postaci
    public float gravity = -10; //przyspieszenie ziemskie 
    Vector3 velocity; //wyliczona prędkość w każdym kierunku
    CharacterController characterController; //komponent Character Controller

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        //velocity.y += gravity * Time.deltaTime;

        //characterController.Move(velocity * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Somethin Collided!!!");
        Debug.Log(hit.gameObject.name);
    }
}
