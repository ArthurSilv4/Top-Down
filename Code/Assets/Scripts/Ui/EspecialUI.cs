using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspecialUI : MonoBehaviour
{
    [SerializeField] private Image imgEspecial;
    [SerializeField] private float velocidade;

    private void LateUpdate()
    {
        float porcentagemEspecial = (float) EspecialControle.currenteEspecial / EspecialControle.maxEspecial;
        imgEspecial.fillAmount = Mathf.Lerp(imgEspecial.fillAmount, porcentagemEspecial, Time.deltaTime * velocidade);
    }
}
