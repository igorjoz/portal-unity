using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool canOpen = false;
    public Door[] doors;
    public KeyColor keyColor;
    public bool isLocked = false;
    Animator key;

    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && !isLocked)
        {
            GameManager.gameManager.SetUseInfo("Press E to open lock");
        }

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
            GameManager.gameManager.redKeyText.text = GameManager.gameManager.redKey.ToString();

            isLocked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && keyColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            GameManager.gameManager.greenKeyText.text = GameManager.gameManager.greenKey.ToString();

            isLocked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && keyColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            GameManager.gameManager.goldKeyText.text = GameManager.gameManager.goldKey.ToString();

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
            GameManager.gameManager.SetUseInfo("");

            Debug.Log("You can not open the door :(");
        }
    }
}
