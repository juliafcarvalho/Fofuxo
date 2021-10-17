using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CondicaoTempo", menuName = "CondicaoVitoria/CondicaoTempo", order = 1)]
public class CondicaoTempo : CondicaoVitoria
{
    private float tempo = 0;
    [Range(5, 25)] public float tempoSeguir = 10;
    public override bool Atingiu()
    {
        tempo += Time.deltaTime;
        if (tempo > tempoSeguir)
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
        tempo = 0;
    }
}
