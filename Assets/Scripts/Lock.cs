using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool canOpen = false;
    public Door[] doors;
    public KeyColor keyColor;
    public bool isLocked = false;
    Animator key;

    public KeyColor color;
    public Material red;
    public Material green;
    public Material gold;
    public Renderer myLock;

    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !isLocked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }

    public bool CheckTheKey()
    {
        if (GameManager.gameManager.redKey > 0 && keyColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            isLocked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && keyColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            isLocked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && keyColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            isLocked = true;
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log("You can open the door now!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log("You can not open the door :(");
        }
    }

    void SetMyColor()
    {
        switch (color)
        {
            case KeyColor.Red:
                myLock.material = red;
                break;
            case KeyColor.Green:
                myLock.material = green;
                break;
            case KeyColor.Gold:
                myLock.material = gold;
                break;
        }
    }
}
