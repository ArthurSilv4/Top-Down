using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial : MonoBehaviour
{
    [SerializeField] float velocidade;

    private VidaInimigo enim;
    private int dano;

    

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        StartCoroutine(Destruir());
        NivelDano();
    }

    IEnumerator Acertou()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }

    //nao Acertou
    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            enim = collision.gameObject.GetComponent<VidaInimigo>();

            if (enim != null)
            {
                enim.ReceberDano(dano);
            }

            StartCoroutine(Acertou());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            Destroy(this.gameObject);
        }
    }

    private void NivelDano()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                dano = 200;
                EspecialControle.maxEspecial = 30;
                break;
            case 2:
                dano = 150;
                EspecialControle.maxEspecial = 20;
                break;
            case 3:
                dano = 100;
                EspecialControle.maxEspecial = 15;
                break;
        }

        if (XpPlayer.nivelAtual > 3)
        {
            dano = 100;
            EspecialControle.maxEspecial = 10;
        }
    }
}

