using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InimigoBase : MonoBehaviour
{
    public int comportamentoAtual = 0;
    public Comportamento[] comportamentos;

    public int etapasGanhas = 0;
    public int etapasNecessarias = 3;
    public Animator anim;

    bool emJogo = true;

    GlitchEffect glitch;
    public AudioClip[] sons;
    AudioSource audioSource;

    public FasesPassadas faseControle;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        glitch = GameObject.Find("Main Camera").GetComponent<GlitchEffect>();

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
        
        if(emJogo)
        {
            comportamentos[comportamentoAtual]._movimentacao.Mover();
            if (comportamentos[comportamentoAtual]._condicaoVitoria.Atingiu())
            {
                audioSource.PlayOneShot(sons[0]);
                etapasGanhas++;
                if (etapasGanhas > etapasNecessarias)
                {
                    faseControle.ConcluiuFase(faseControle.faseAtual);
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
        glitch.intensity = 1;
        glitch.flipIntensity = 1;
        glitch.colorIntensity = 1;

        emJogo = false;
        anim.SetBool("attack", true);
        yield return new WaitForSecondsRealtime(1f);
        TrocarDesafio();
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        anim.SetBool("attack", false);
        emJogo = true;

        glitch.intensity = 0;
        glitch.flipIntensity = 0;
        glitch.colorIntensity = 0;
    }

    IEnumerator FimChefe()
    {
        anim.SetTrigger("morte");

        glitch.intensity = 1;
        glitch.flipIntensity = 1;
        glitch.colorIntensity = 1;

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);

        Jogador.jogador.valores.velocidade += 5;
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
            comportamentos[comportamentoAtual]._movimentacao.ResetPosition();
        }
    }
}
