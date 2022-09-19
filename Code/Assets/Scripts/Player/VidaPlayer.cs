using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaPlayer : MonoBehaviour
{

    public static int maxVida;
    public static int currenteVida;

    private void Start()
    {
        maxVida = 100;
        currenteVida = maxVida;
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vida"))
        {
            currenteVida += 5;
            Destroy(collision.gameObject);
        }
    }
}
