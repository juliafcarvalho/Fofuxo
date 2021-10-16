using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoCanvas : Ouvinte
{
    public ValoresJogador valores;
    public Ouvinte ouvinte;
    public Slider barraDeVida;

    private void Awake()
    {
        ouvinte = this.GetComponent<Ouvinte>();
        barraDeVida = transform.GetChild(0).GetComponent<Slider>();
        
    }
    void Start()
    {
        valores = Jogador.jogador.valores;
        valores.RegisterListener(ouvinte);
        barraDeVida.maxValue = valores.vidaMaxima;
        barraDeVida.value = valores.vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void JogadorLevouDano()
    {
        barraDeVida.value = valores.vida;
    }
}
