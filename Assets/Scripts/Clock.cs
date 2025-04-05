using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime; // true -> dodawanie czasu; false -> odejmowanie czasu
    public int time = 5;
    public AudioClip playClip;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(playClip);

        if (addTime)
        {
            GameManager.gameManager.AddTime(time);
        }
        else
        {
            GameManager.gameManager.AddTime(-time);
        }

        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(2f, 0, 0));
    }
}
