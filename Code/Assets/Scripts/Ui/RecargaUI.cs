using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecargaUI : MonoBehaviour
{
    [SerializeField] private Image recarga;
    [SerializeField] private float velocidade;

    private void LateUpdate()
    {
        float porcentagemRecarga = (float)RecargaPlayer.currentRecarga / RecargaPlayer.maxRecarga;
        recarga.fillAmount = Mathf.Lerp(recarga.fillAmount, porcentagemRecarga, Time.deltaTime * velocidade);
    }
}
