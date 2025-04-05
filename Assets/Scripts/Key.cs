using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Gold,
}

public class Key : PickUp
{
    public KeyColor color;
    public AudioClip playClip;

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(playClip);

        GameManager.gameManager.AddKey(color);

        Destroy(this.gameObject);
    }
}
