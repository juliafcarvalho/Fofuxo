using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CondicaoColeta", menuName = "CondicaoVitoria/CondicaoColeta", order = 2)]
public class CondicaoColeta : CondicaoVitoria
{
    public GameObject coletavel; 
    public int coletasNecessarias = 3;
    int coletados = 0;
    public override bool Atingiu()
    {
        if (coletados >= coletasNecessarias)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Zerar()
    {
        coletados = 0;
    }

    public override void Configurar()
    {
        CriarColetavel();
    }
    public override void Acao()
    {
        coletados++;
        if (coletados < coletasNecessarias)
        {
            CriarColetavel();
        }
    }

    public virtual void CriarColetavel()
    {
        int aux = Random.Range(0, 4); //0 - tocandoEsquerda, 1 - tocandoDireita, 2 - tocandoCima e 3 - tocandoBaixo
        float pos;
        GameObject criacao = new GameObject();

        switch (aux)
        {
            case 0:
                pos = Random.Range(10f, -10f);
                criacao = Instantiate(coletavel, new Vector2(-13, pos), Quaternion.identity);
                break;
            case 1:
                pos = Random.Range(10f, -10f);
                criacao = Instantiate(coletavel, new Vector2(12, pos), Quaternion.identity);
                break;
            case 2:
                pos = Random.Range(-12.5f, -12.5f);
                criacao = Instantiate(coletavel, new Vector2(pos, 10.5f), Quaternion.identity);
                break;
            case 3:
                pos = Random.Range(-12.5f, -12.5f);
                criacao = Instantiate(coletavel, new Vector2(pos, -10.8f), Quaternion.identity);
                break;
        }

        criacao.GetComponent<Coletavel>().condicaoVitoria = this;
    }
}
