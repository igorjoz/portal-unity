using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    public int freezeTime = 10;
    public AudioClip playClip;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(playClip);

        GameManager.gameManager.FreezeTime(freezeTime);

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
}
