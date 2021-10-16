using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMapa : MonoBehaviour
{
    public ValoresJogador valores;
    public Slider barraDeVida;

    private void Awake()
    {
        barraDeVida = transform.GetChild(0).GetComponent<Slider>();

    }
    void Start()
    {
        barraDeVida.maxValue = valores.vidaMaxima;
        barraDeVida.value = valores.vida;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
