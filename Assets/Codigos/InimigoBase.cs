using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InimigoBase : MonoBehaviour
{
    public int comportamentoAtual = 0;
    public Comportamento[] comportamentos;
    public Text feedback;
    private void Awake()
    {
        feedback.enabled = false;
        for (int i = 0; i < comportamentos.Length; i++)
        {
            comportamentos[i]._objeto = this.gameObject.GetComponent<InimigoBase>();
            comportamentos[i].Limpar();
        }
    }
    void Start()
    {
        //StartCoroutine(trocarDesafio());
    }

    public void Update()
    {
        if(!feedback.isActiveAndEnabled)
        {
            comportamentos[comportamentoAtual].Mover();

            if (comportamentos[comportamentoAtual].Atingiu())
            {
                StartCoroutine(Trocar());
            }
        }        
    }

    IEnumerator Trocar()
    {
        Time.timeScale = 0;
        feedback.enabled = true;
        yield return new WaitForSecondsRealtime(1f);
        TrocarDesafio();
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        feedback.enabled = false;
    }
    public void TrocarDesafio()
    {
        int aux = Random.Range(0, comportamentos.Length);
        //if (comportamentoAtual != aux)
        {
            comportamentos[comportamentoAtual].AcabarEstado();
            comportamentoAtual = aux;
            Jogador.jogador.TrocarEstado(comportamentoAtual);

            comportamentos[comportamentoAtual].ConfiguracoesEstado();
            comportamentos[comportamentoAtual].Mover();
            comportamentos[comportamentoAtual].Atacar();
        }
    }
    /*
    IEnumerator TD()
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
    */
}
