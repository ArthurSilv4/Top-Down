using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaControle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprit;

    [SerializeField] private Transform player;
    [SerializeField] private Transform armaAux;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(mousePosition.x < screenPoint.x)
        {
            sprit.flipY = true;     //Atirando esquerda
        }
        else
        {
            sprit.flipY = false;    //atirando direita
        }

        //Virar pra onde atira
        if(sprit.flipY == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            player.transform.localScale = ControlePlayer.olhandoEsquerda;
            armaAux.transform.localScale = ControlePlayer.armaEsquerda;
        }
        if(sprit.flipY == false && Input.GetKeyDown(KeyCode.Mouse1))
        {
            player.transform.localScale = ControlePlayer.olhandoDireita;
            armaAux.transform.localScale = ControlePlayer.armaDireita;
        }
    }
}
