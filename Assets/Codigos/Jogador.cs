using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public ValoresJogador valores;

    public static Jogador jogador;

    public Rigidbody2D rb2D;
    public float movHorizontal, movVertical;
    public bool tocandoDireita, tocandoEsquerda, tocandoCima, tocandoBaixo;

    public int velocidadeAtual = 15;

    public comportamentoJogador atualJogador;
    [HideInInspector] public AudioSource audioSource;

    public AudioClip[] sons;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        jogador = this;
        valores.LimparOuvintes();
    }

    public void tocarSom(int qual)
    {
        audioSource.PlayOneShot(sons[qual]);
    }
    void Start()
    {
        //atualJogador = comportamentoJogador.MovBasica;
    }


    void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal");
        movVertical = Input.GetAxisRaw("Vertical");
    }
    public void TrocarEstado(comportamentoJogador novoEstado)
    {
        atualJogador = novoEstado;
        rb2D.velocity = Vector2.zero;

        switch (atualJogador)
        {
            case comportamentoJogador.MovBasica:
                //this.transform.position = new Vector3(0, 0, 0);
                this.rb2D.position = new Vector3(0, -10.85f, 0);
                break;
            case comportamentoJogador.MovBorda:
                this.rb2D.position = new Vector3(0, -10.85f, 0);
                break;
            case comportamentoJogador.MovVertical:
                this.rb2D.position = new Vector3(-10f, 0, 0);
                break;
            case comportamentoJogador.MovHorizontal:
                this.rb2D.position = new Vector3(0, -4.2f, 0);
                break;
        }
    }

    private void FixedUpdate()
    {
        
        switch (atualJogador)
        {
            case comportamentoJogador.MovBasica:
                MovBasica();
                break;
            case comportamentoJogador.MovBorda:
                MovBorda();
                break;
            case comportamentoJogador.MovVertical:
                MovVertical();
                break;
            case comportamentoJogador.MovHorizontal:
                MovHorizontal();
                break;
        }

    }
    public void MovVertical()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, movVertical * velocidadeAtual);
    }
    public void MovHorizontal()
    {
        rb2D.velocity = new Vector2(movHorizontal * velocidadeAtual, rb2D.velocity.y);
    }
    public void MovBasica()
    {
        Vector2 normalizacao = new Vector2(movHorizontal, movVertical).normalized;
        rb2D.velocity = normalizacao * velocidadeAtual;
    }

    public void MovBorda()
    {
        if (movHorizontal != 0 && movVertical != 0)
        {
            movHorizontal = 0f;
        }
        if (tocandoBaixo)
        {
            if (!tocandoEsquerda && !tocandoDireita)
            {
                movVertical = -1;
            }
        }
        else if (tocandoEsquerda)
        {
            if (!tocandoCima)
            {
                movHorizontal = -1;
            }
        }

        else if (tocandoDireita)
        {
            if (!tocandoCima)
            {
                movHorizontal = 1;
            }
        }

        else if (tocandoCima)
        {
            movVertical = 1;
            //rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        Vector2 aux = new Vector2(movHorizontal, movVertical);
        rb2D.velocity = aux * velocidadeAtual;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.collider.name)
        {
            case "tocandoEsquerda":
                tocandoEsquerda = true;
                break;
            case "tocandoDireita":
                tocandoDireita = true;
                break;
            case "tocandoCima":
                tocandoCima = true;
                break;
            case "tocandoBaixo":
                tocandoBaixo = true;
                break;
        }        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "tocandoEsquerda":
                tocandoEsquerda = false;
                break;
            case "tocandoDireita":
                tocandoDireita = false;
                break;
            case "tocandoCima":
                tocandoCima = false;
                break;
            case "tocandoBaixo":
                tocandoBaixo = false;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dano")
        {
            tocarSom(0);
            valores.DiminuirVida(1);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Inimigo")
        {
            tocarSom(0);
            valores.DiminuirVida(1);
            TrocarEstado(atualJogador);
        }
    }

}
