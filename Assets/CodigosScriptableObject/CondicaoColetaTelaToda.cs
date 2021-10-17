using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CondicaoColeta", menuName = "CondicaoVitoria/CondicaoColeta Telatoda", order = 2)]
public class CondicaoColetaTelaToda : CondicaoColeta
{
    public override void CriarColetavel()
    {
        GameObject criacao;

        float auxX = Random.Range(-10, 10);
        float auxY = Random.Range(-12.5f, 12f);

        criacao = Instantiate(coletavel, new Vector2(auxX, auxY), Quaternion.identity);
        criacao.GetComponent<Coletavel>().condicaoVitoria = this;
    }
}
