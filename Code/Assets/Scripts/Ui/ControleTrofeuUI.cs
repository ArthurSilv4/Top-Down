using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTrofeuUI : MonoBehaviour
{
    public GameObject spawn;
    public GameObject destruido;

    public static bool spawndado;

    private void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if(spawndado == true)
        {
            destruido.SetActive(false);

            spawn.SetActive(true);
        }
        else
        {
            destruido.SetActive(true);

            spawn.SetActive(false);

            yield return new WaitForSeconds(5.5f);
            destruido.SetActive(false);
        }
    }
}
