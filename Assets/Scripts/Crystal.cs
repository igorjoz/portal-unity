using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int pointsToAdd = 5;
    public AudioClip playClip;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(playClip);

        GameManager.gameManager.AddPoints(pointsToAdd);

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
        transform.Rotate(new Vector3(0, 0, 2f));
    }
}
