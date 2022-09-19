using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trofeu : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(Destruir());
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(70f);
        Destroy(gameObject);
        SawnTrofeu.quantia--;

        ControleTrofeuUI.spawndado = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SawnTrofeu.trofeuCorrente += 1;

            Destroy(this.gameObject);
        }
    }
}
