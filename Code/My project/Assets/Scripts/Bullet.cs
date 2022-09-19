using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocidade;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        StartCoroutine(Destruir());
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
