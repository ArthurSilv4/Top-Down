using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargaPlayer : MonoBehaviour
{
    public static float maxRecarga;
    public static float currentRecarga;

    void Start()
    {
        maxRecarga = 10;
        currentRecarga = 0;
    }

    void Update()
    {
        
    }

    public static void Regarregar()
    {
        currentRecarga = 10;
    }

    public static void Voltar()
    {
        currentRecarga = -10;

    }
}
