using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;

    [SerializeField] private GameObject scriptInimigo;
    [SerializeField] private GameObject explosao;

    [SerializeField] private Animator armaAnin;
    [SerializeField] private Animator anin;
    [SerializeField] private Rigidbody2D rig;

    [SerializeField] private GameObject poucaBala;
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject especialBala;
    [SerializeField] private Transform spawnBala;

    [SerializeField] private float velocidadeMoimento;

    private float deleiAcido;
    private float deleiAtirar;
    private float tempoAtualTiro;

    

    private Vector2 movimento;

    public static bool morto;


    void Start()
    {
        

        morto = false;

        explosao.SetActive(false);

        scriptInimigo.GetComponent<Inimigo>().enabled = true;

        tempoAtualTiro = 0.85f;

        render.gameObject.GetComponent<SpriteRenderer>();
        rig.gameObject.GetComponent<Rigidbody2D>();
        anin.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        Animacao();
        Rotacao();
        Atirar();
        StartCoroutine(HabilidadeEspecial());
        StartCoroutine(Recarregar());
        StartCoroutine(MudarACor());

        
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + movimento.normalized * velocidadeMoimento * Time.fixedDeltaTime);

        NivelPlay();
    }

    void Rotacao()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) //Olhando direita
        {
            render.flipX = false;
        }
        if (Input.GetAxisRaw("Horizontal") < 0) //Olhando esquerda
        {
            render.flipX = true;
        }
    }

    IEnumerator Recarregar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ArmaControle.municaoAtual != ArmaControle.penteTotal)
            {
                RecargaPlayer.Regarregar();

                yield return new WaitForSeconds(0.8f);
                ArmaControle.municaoAtual = ArmaControle.penteTotal;

                yield return new WaitForSeconds(0.1f);
                RecargaPlayer.Voltar();
            }
        }
    }

    void Atirar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (deleiAtirar <= 0 && ArmaControle.municaoAtual > 0)
            {
                armaAnin.SetTrigger("Fire");

                anin.SetBool("Atirando", true);

                deleiAtirar = tempoAtualTiro;

                ArmaControle.municaoAtual--;

                Instantiate(bala, spawnBala.position, spawnBala.rotation);
            }
        }
        else
        {
            anin.SetBool("Atirando", false);
        }

        if (deleiAtirar > 0)
        {
            deleiAtirar -=  Time.deltaTime;
        }
    }

    IEnumerator HabilidadeEspecial()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(EspecialControle.currenteEspecial >= EspecialControle.maxEspecial && ArmaControle.municaoAtual >= 10)
            {
                armaAnin.SetTrigger("Fire");

                anin.SetBool("Atirando", true);

                EspecialControle.currenteEspecial = 0;

                ArmaControle.municaoAtual = 0;
                
                Instantiate(especialBala, spawnBala.position, spawnBala.rotation);
            }

            if(EspecialControle.currenteEspecial >= EspecialControle.maxEspecial && ArmaControle.municaoAtual < 10)
            {
                poucaBala.SetActive(true);

                yield return new WaitForSeconds(3);

                poucaBala.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Acido"))
        {
            deleiAcido -= Time.deltaTime;

            if (deleiAcido <= 0)
            {
                VidaPlayer.currenteVida -= 5;

                Inimigo.tomandoDano = true;

                deleiAcido = 1.5f;

            }
        }
    }

    

    IEnumerator MudarACor()
    {
        if (Inimigo.tomandoDano == true)
        {
            render.color = Color.red;

            yield return new WaitForSeconds(0.5f);

            render.color = Color.white;
        }
    }

    void Animacao()
    {
        //Andando
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anin.SetBool("Andando", true);
        }
        else
        {
            anin.SetBool("Andando", false);
        }

        if (VidaPlayer.currenteVida <= 0)
        {
            morto = true;


            anin.SetBool("Morrendo", true);

            explosao.SetActive(true);

            gameObject.GetComponent<ControlePlayer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            scriptInimigo.GetComponent<Inimigo>().enabled = false;
        }
        else
        {
            morto = false;
        }
    }

    void NivelPlay()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                velocidadeMoimento = 5;
                tempoAtualTiro = 1f;
                break;
            case 2:
                velocidadeMoimento = 6;
                tempoAtualTiro = 0.8f;
                break;
            case 3:
                velocidadeMoimento = 7;
                tempoAtualTiro = 0.5f;
                break;
            case 4:
                velocidadeMoimento = 8;
                tempoAtualTiro = 0.4f;
                break;
        }

        if (XpPlayer.nivelAtual > 4)
        {
            velocidadeMoimento = 9;
            tempoAtualTiro = 0.35f;
        }


    }
}
