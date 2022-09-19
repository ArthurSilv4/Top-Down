using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpUI : MonoBehaviour
{
    public Text nivel;

    [SerializeField] private Image xp;
    [SerializeField] private float velocidade;

    private void LateUpdate()
    {
        nivel.text = XpPlayer.nivelAtual.ToString("0");

        float porcentagemXp = (float)XpPlayer.currenteXp / XpPlayer.maxXp;
        xp.fillAmount = Mathf.Lerp(xp.fillAmount, porcentagemXp, Time.deltaTime * velocidade);
    }
}
