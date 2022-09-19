using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaControle : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] GameObject semMunicao;
    [SerializeField] GameObject iconeAlerta;

    [SerializeField] private Text txtPente;
    [SerializeField] private Text txtMunicaoAtual;

    [SerializeField] private SpriteRenderer spritePlayer;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform player;

    public static int municaoAtual;
    public static int penteTotal;

    private void Start()
    {
        municaoAtual = penteTotal;
    }

    void Update()
    {
        NivelArma();
        ExibirUI();

        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePosition.x < screenPoint.x);

        if (Input.GetKeyDown(KeyCode.Mouse1) && sprite.flipY == true)
        {
            spritePlayer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && sprite.flipY == false)
        {
            spritePlayer.flipX = false;
        }
    }

    void ExibirUI()
    {
        txtPente.text = penteTotal.ToString("00");
        txtMunicaoAtual.text = municaoAtual.ToString("00");

        if(municaoAtual <= 5)
        {
            iconeAlerta.SetActive(true);
            anim.SetBool("PoucaBala", true);
        }
        else
        {
            iconeAlerta.SetActive(false);
            anim.SetBool("PoucaBala", false);
        }

        if(municaoAtual <= 0)
        {
            semMunicao.SetActive(true);
        }
        else
        {
            semMunicao.SetActive(false);
        }
    }

    //Inimigo tem 100 DE vida
    void NivelArma()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 0:
                penteTotal = 10;
                break;
            case 1:
                penteTotal = 10;
                break;
            case 2:
                penteTotal = 15;
                break;
            case 3:
                penteTotal = 20;
                break;
            case 4:
                penteTotal = 25;
                break;
            case 5:
                penteTotal = 30;
                break;
        }

        if(XpPlayer.nivelAtual > 5)
        {
            penteTotal = 35;
        }
    }
}
