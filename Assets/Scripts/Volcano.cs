using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : Props
{
    public float bouncePower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerController pController = collision.transform.GetComponent<PlayerController>();
            if (pController == null) return;
            float speed = pController.GetSpeed();
            speed *= bouncePower;
            pController.SetSpeed(speed);
        }
    }
}
