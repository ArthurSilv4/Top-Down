using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text Textsegundos;
    public Text Textminutos;
    public Text TextPontos;

    public Text TextScorePassado;

    public static float pontos;

    public static int minutos;
    private int limiteSegundos;
    public static float segundos;

    public static float scorePassado;

    private void Start()
    {
        minutos = 0;
        segundos = 0;
        pontos = 0;

        limiteSegundos = 60;
    }

    void FixedUpdate()
    {

        Textsegundos.text = segundos.ToString("00");
        Textminutos.text = minutos.ToString("00");

        TextScorePassado.text = scorePassado.ToString("0");
        TextPontos.text = pontos.ToString("0");

        if (ControlePlayer.morto == false)
        {
            segundos += Time.deltaTime;

            if (segundos >= limiteSegundos)
            {
                minutos++;
                segundos = 0 + 1;
            }
        }

        if(pontos > scorePassado)
        {
            scorePassado = pontos;
        }
    }
}
