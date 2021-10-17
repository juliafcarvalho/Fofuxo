using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoCanvas : Ouvinte
{
    public ValoresJogador valores;
    public Ouvinte ouvinte;
    public Text vidaJogador;
    public Text fasesRealizadas;
    public InimigoBase inimigo;
    private void Awake()
    {
        ouvinte = this.GetComponent<Ouvinte>();

        vidaJogador = transform.GetChild(0).GetComponent<Text>();
        fasesRealizadas = transform.GetChild(1).GetComponent<Text>();

        inimigo = FindObjectOfType<InimigoBase>();


    }
    void Start()
    {
        valores = Jogador.jogador.valores;
        valores.RegisterListener(ouvinte);
        vidaJogador.text = valores.vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        fasesRealizadas.text = inimigo.etapasGanhas.ToString();
    }

    public override void JogadorLevouDano()
    {
        vidaJogador.text = valores.vida.ToString();

    }
}
