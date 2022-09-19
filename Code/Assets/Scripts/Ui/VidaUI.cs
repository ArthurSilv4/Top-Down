using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour
{
    [SerializeField] private Image vida;
    [SerializeField] private float velocidade;

    private void LateUpdate()
    {
        float porcentagemVida = (float) VidaPlayer.currenteVida / VidaPlayer.maxVida;
        vida.fillAmount = Mathf.Lerp(vida.fillAmount, porcentagemVida, Time.deltaTime * velocidade);
    }
}
