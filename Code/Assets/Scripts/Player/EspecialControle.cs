using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspecialControle : MonoBehaviour
{
    public static float currenteEspecial;
    public static float maxEspecial;

    private void Start()
    {
        maxEspecial = 10;
        currenteEspecial = 0;
    }

    
    void Update()
    {
        if (currenteEspecial < maxEspecial)
        {
            currenteEspecial += Time.deltaTime;
        }
    }
}
