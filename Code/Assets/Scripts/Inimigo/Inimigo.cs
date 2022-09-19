using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private Transform posicaoPlayer;
    [SerializeField] private float velocidade;

    [SerializeField] private SpriteRenderer inimigo;

    public static bool tomandoDano;

    private int danoInimigo;

    private float delei;
    private float deleiAtaque;

    void Start()
    {
        this.anim.GetComponent<Animator>();

        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        this.inimigo.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(posicaoPlayer.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoPlayer.position, velocidade * Time.deltaTime);
        }

        //virar inimigo
        if(this.posicaoPlayer.position.x < this.transform.position.x)
        {
            this.inimigo.flipX = true;
        }
        else
        {
            this.inimigo.flipX = false;
        }

        delei -= Time.deltaTime;



        NivelAtaque();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(delei <= 0)
            {
                DanoPlayeer();
            }
        }
        else
        {
            tomandoDano = false;
        }


        if (collision.gameObject.CompareTag("Fora"))
        {
            Destroy(gameObject);
        }
    }

    private void DanoPlayeer()
    {
        anim.SetTrigger("AtacandoInimigo");

        tomandoDano = true;

        VidaPlayer.currenteVida -= danoInimigo;

        delei = deleiAtaque;
    }

        //Player tem 100 de vida
        private void NivelAtaque()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                deleiAtaque = 2;
                danoInimigo = 10;
                velocidade = 3;
                break;
            case 2:
                deleiAtaque = 1.5f;
                danoInimigo = 15;
                velocidade = 4;
                break;
            case 3:
                deleiAtaque = 1.2f;
                danoInimigo = 17;
                velocidade = 5f;
                break;
        }

        if (XpPlayer.nivelAtual > 3)
        {
            deleiAtaque = 0.8f;
            danoInimigo = 20;
            velocidade = 7f;
        }
    }
}
