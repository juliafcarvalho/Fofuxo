using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public ValoresJogador valores;
    public CarregarScene carregar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            valores.LimparValores();
            carregar.IrParaScene(1);
        }
    }
}
