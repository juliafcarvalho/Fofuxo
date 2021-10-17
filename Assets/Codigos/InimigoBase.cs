using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InimigoBase : MonoBehaviour
{
    public int comportamentoAtual = 0;
    public Comportamento[] comportamentos;
    public Text feedback;

    public int etapasGanhas = 0;
    public int etapasNecessarias = 3;

    private void Awake()
    {
        feedback.enabled = false;
        for (int i = 0; i < comportamentos.Length; i++)
        {
            comportamentos[i]._objeto = this.gameObject.GetComponent<InimigoBase>();
            comportamentos[i]._movimentacao._objeto = this.gameObject.GetComponent<InimigoBase>();
            comportamentos[i].Limpar();
        }
    }
    void Start()
    {
        TrocarDesafio();
    }

    public void Update()
    {
        
        if(!feedback.isActiveAndEnabled)
        {
            comportamentos[comportamentoAtual]._movimentacao.Mover();
            if (comportamentos[comportamentoAtual]._condicaoVitoria.Atingiu())
            {
                etapasGanhas++;
                if (etapasGanhas > etapasNecessarias)
                {
                    StartCoroutine(FimChefe());
                }
                else
                {
                    StartCoroutine(Trocar());
                }                
            }
        }        
    }

    IEnumerator Trocar()
    {
        Time.timeScale = 0;
        feedback.enabled = true;
        feedback.text = "REVIRAVOLTA?";
        yield return new WaitForSecondsRealtime(1f);
        TrocarDesafio();
        feedback.text = "Veremos...";
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        feedback.enabled = false;
    }

    IEnumerator FimChefe()
    {
        Time.timeScale = 0;
        feedback.enabled = true;
        feedback.text = "Vitoria";
        yield return new WaitForSecondsRealtime(1f);
        Jogador.jogador.valores.velocidade += 5;
        feedback.text = "...um presente...";
        comportamentos[comportamentoAtual].Limpar();
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Mapa");
    }
    public void TrocarDesafio()
    {
        int aux = Random.Range(0, comportamentos.Length);
        //if (comportamentoAtual != aux)
        {
            comportamentos[comportamentoAtual].AcabarEstado();
            comportamentoAtual = aux;
            Jogador.jogador.TrocarEstado(comportamentos[comportamentoAtual]._comportamentoJogador);

            comportamentos[comportamentoAtual].ConfiguracoesEstado();
            comportamentos[comportamentoAtual].Atacar();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Jogador aux = collision.GetComponent<Jogador>();
            aux.valores.DiminuirVida(1);
            aux.TrocarEstado(comportamentos[comportamentoAtual]._comportamentoJogador);
            comportamentos[comportamentoAtual]._movimentacao.ResetPosition();
        }
    }
}
