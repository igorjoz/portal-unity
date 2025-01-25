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
    public LayerMask groundMask; //grupa obiektów, które bêd¹ warstw¹ uznawan¹ za teren

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
        RaycastHit hit; //zmienna w której zapisywana jest referencja do uderzonego obiektu

        if (Physics.Raycast(groundCheck.position,
        transform.TransformDirection(Vector3.down),
        out hit, 0.4f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag; // sprawdzamy tag tego w co uderzyliœmy
            switch (terrainType)
            {
                default: //standardowa prêdkoœæ gdy chodzimy po dowolnym terenie
                    speed = 12;
                    break;
                case "Low": //prêdkoœæ gdy chodzimy po terenie spowalniaj¹cym
                    speed = 3;
                    break;
                case "High": //prêdkoœæ gdy chodzimy po terenie przyspieszaj¹cym
                    speed = 20;
                    break;
            }
        }
    }
}
