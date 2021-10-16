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
        TrocarDesafio();
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
            Jogador.jogador.TrocarEstado(comportamentos[comportamentoAtual].escolha);

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
            aux.TrocarEstado(comportamentos[comportamentoAtual].escolha);
            comportamentos[comportamentoAtual].ResetPosition();
        }
    }
}
