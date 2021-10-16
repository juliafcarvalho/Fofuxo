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
            comportamentos[i]._objeto = this.gameObject.GetComponent<InimigoBase>();
            comportamentos[i].Limpar();
        }
    }
    void Start()
    {
        StartCoroutine(trocarDesafio());
    }

    public void Update()
    {
        comportamentos[comportamentoAtual].Mover();
    }

    IEnumerator trocarDesafio()
    {
        while (true)
        {
            int aux = Random.Range(0, comportamentos.Length);
            print(aux);
            if(comportamentoAtual != aux)
            {
                comportamentos[comportamentoAtual].AcabarEstado();
                comportamentoAtual = aux;
                Jogador.jogador.TrocarEstado(comportamentoAtual);

                comportamentos[comportamentoAtual].ConfiguracoesEstado();
                comportamentos[comportamentoAtual].Mover();
                comportamentos[comportamentoAtual].Atacar();
            }
            
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }

    }
}
