using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Minhas coisas", menuName = "Jogador/Valores", order = 1)]
public class ValoresJogador : ScriptableObject
{
    public List<Ouvinte> ouvintes = new List<Ouvinte>();
    public int vida = 3;
    public int vidaMaxima = 3;
    public float velocidade = 15f;
    public bool invencivel = false;

    private void Awake()
    {
        
    }
    public void RegisterListener(Ouvinte listener)
    {
        ouvintes.Add(listener); 
    }

    public void DiminuirVida(int dano)
    {
        if(!invencivel)
        {
            vida -= dano;
            if(vida <= 0)
            {
                SceneManager.LoadScene("Derrota");
                LimparOuvintes();
            }
        }
        for (int i = ouvintes.Count - 1; i >= 0; i--)
            ouvintes[i].JogadorLevouDano();
    }

    public void LimparOuvintes()
    {
        ouvintes.Clear();
    }

    public void LimparValores()
    {
        vida = 3;
        vidaMaxima = 3;        
        velocidade = 5f;
    }
}
