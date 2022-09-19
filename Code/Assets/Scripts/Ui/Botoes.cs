using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botoes : MonoBehaviour
{
    public Text Textsegundos;
    public Text Textminutos;
    public Text TextPontos;
    public Text TextTrofeu;

    public Text TextsegundosVitoria;
    public Text TextminutosVitoria;
    public Text TextPontosVitoria;

    public GameObject canvasVitoria;
    public GameObject canvasInicial;
    public GameObject canvasSobre;
    public GameObject canvasPause;
    public GameObject canvasGameOver;

    private bool canvasInicialON;

    void Start()
    {
        PauseOn();

        canvasSobre.SetActive(false);
        canvasInicial.SetActive(true);
        canvasPause.SetActive(false);
        canvasGameOver.SetActive(false);

        canvasInicialON = true;

    }

    private void Update()
    {
        GameOver();

        if (SawnTrofeu.trofeuCorrente >= 5)
        {
            StartCoroutine(Vitoria());
        }

        if (Input.GetKey(KeyCode.Escape) && canvasInicialON == false)
        {
            PausadoON();
        }
    }


    public void GameOver()
    {
        Textsegundos.text = Cronometro.segundos.ToString("00");
        Textminutos.text = Cronometro.minutos.ToString("00");

        TextTrofeu.text = SawnTrofeu.trofeuCorrente.ToString("0");

        TextPontos.text = Cronometro.pontos.ToString("0");

        if (ControlePlayer.morto == true)
        {
            canvasGameOver.SetActive(true);
        }
    }

    IEnumerator Vitoria()
    {
        yield return new WaitForSeconds(0.5f);

        PauseOn();

        canvasVitoria.SetActive(true);

        TextsegundosVitoria.text = Cronometro.segundos.ToString("00");
        TextminutosVitoria.text = Cronometro.minutos.ToString("00");

        TextPontosVitoria.text = Cronometro.pontos.ToString("0");
    }

    public void Play()
    {
        PauseOFF();

        canvasInicial.SetActive(false);

        canvasInicialON = false;
    }

    public void SobreOpen()
    {
        canvasSobre.SetActive(true);
    }

    public void SobreOFF()
    {
        canvasSobre.SetActive(false);
    }

    public void PausadoON()
    {
        canvasPause.SetActive(true);

        PauseOn();

    }

    public void PausadoOFF()
    {
        canvasPause.SetActive(false);

        PauseOFF();
    }

    public void Reiniciar()
    {
        canvasPause.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseOn()
    {
        Time.timeScale = 0;
    }

    void PauseOFF()
    {
        Time.timeScale = 1;
    }
}
