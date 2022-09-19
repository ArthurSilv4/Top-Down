using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;

    public GameObject spritXp;

    public static int maxVida;
    public static int currenteVida;

    private void Start()
    {
        maxVida = 100;
        currenteVida = maxVida;
    }

    public void ReceberDano(int dano)
    {
        StartCoroutine(MudarACor());

        currenteVida -= dano;


        if (currenteVida <= 0)
        {
            Destroy(this.gameObject);

            Instantiate(spritXp, this.transform.position, this.transform.rotation);

            Cronometro.pontos += 7.4f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosao"))
        {
            StartCoroutine(MudarACor());

            Destroy(gameObject, 2f);
        }
    }

    IEnumerator MudarACor()
    {
        
            render.color = Color.red;

            yield return new WaitForSeconds(0.5f);

            render.color = Color.white;
        
    }
}
