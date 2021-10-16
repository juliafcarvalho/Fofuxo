using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBase : MonoBehaviour
{
    public int comportamentoAtual = 0;
    public Comportamento[] comportamentos;
    private void Awake()
    {
        for (int i = 0; i < comportamentos.Length; i++)
        {
            comportamentos[i]._objeto = this.gameObject;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        comportamentos[comportamentoAtual].Mover(this.gameObject);
    }
}
