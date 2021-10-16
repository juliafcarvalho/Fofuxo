using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenciadorBatalha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(trocarDesafio());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator trocarDesafio()
    {
        while(true)
        {
            Jogador.jogador.TrocarEstado();
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }        

    }
}
