using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float gravity = -9.81f;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck; //miejsce na nasz obiekt
    public LayerMask groundMask; //grupa obiekt�w, kt�re b�d� warstw� uznawan� za teren

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    void PlayerMove()
    {
        RaycastHit hit; //zmienna w kt�rej zapisywana jest referencja do uderzonego obiektu

        if (Physics.Raycast(groundCheck.position,
        transform.TransformDirection(Vector3.down),
        out hit, 0.4f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag; // sprawdzamy tag tego w co uderzyli�my
            switch (terrainType)
            {
                default: //standardowa pr�dko�� gdy chodzimy po dowolnym terenie
                    speed = 12;
                    break;
                case "Low": //pr�dko�� gdy chodzimy po terenie spowalniaj�cym
                    speed = 3;
                    break;
                case "High": //pr�dko�� gdy chodzimy po terenie przyspieszaj�cym
                    speed = 20;
                    break;
            }
        }
    }
}
