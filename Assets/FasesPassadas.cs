using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FasesPassadas", menuName = "FasesPassadas", order = 1)]
public class FasesPassadas : ScriptableObject
{
    public bool[] faseLiberada = new bool[4];
    public MovSimples jogador;
    public Vector2 ultimaPos;

    public void Iniciar()
    {
        for(int i = 0; i < faseLiberada.Length; i++)
        {
            faseLiberada[i] = false;
        }
    }

    public void ConcluiuFase(int qualFase)
    {
        faseLiberada[qualFase - 1] = true;
    }

    
}
