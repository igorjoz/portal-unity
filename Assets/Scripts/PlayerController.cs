using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float gravity = -9.81f;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck; // miejsce na obiekt
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Debug.DrawRay(groundCheck.position, transform.TransformDirection(Vector3.down) * 0.4f, Color.red);

        //if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        //{
        //    Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
        //}
        //else
        //{
        //    Debug.Log("Raycast did not hit anything.");
        //}

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
            {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 8f;
                    break;
                case "Low": // teren spowalniaj¹cy
                    speed = 1f;
                    break;
                case "High": // teren przyspieszaj¹cy
                    speed = 50f;
                    break;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
