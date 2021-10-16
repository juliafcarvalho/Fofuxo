using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public ValoresJogador valores;

    public static Jogador jogador;

    public Rigidbody2D rb2D;
    public int movimentacaoJogador = 0;
    public float movHorizontal, movVertical;
    public bool tocandoDireita, tocandoEsquerda, tocandoCima, tocandoBaixo;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jogador = this;
        valores.LimparOuvintes();
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void TrocarEstado()
    {
        movimentacaoJogador++;
        rb2D.velocity = Vector2.zero;
        if (movimentacaoJogador == 4)
        {
            movimentacaoJogador = 0;
        }

        switch (movimentacaoJogador)
        {
            case 0:
                this.transform.position = new Vector3(0, 0, 0);
                break;
            case 1:
                this.transform.position = new Vector3(0, -4.5f, 0);
                break;
            case 2:
                this.transform.position = new Vector3(-4.5f, 0, 0);
                break;
            case 3:
                this.transform.position = new Vector3(0, -4.2f, 0);
                break;
        }
    }

    private void FixedUpdate()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal");
        movVertical = Input.GetAxisRaw("Vertical");
        switch (movimentacaoJogador)
        {
            case 0:
                MovBasica();
                break;
            case 1:
                MovBorda();
                break;
            case 2:
                MovVertical();
                break;
            case 3:
                MovHorizontal();
                break;
        }

    }
    public void MovVertical()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, movVertical * valores.velocidade);
    }
    public void MovHorizontal()
    {
        rb2D.velocity = new Vector2(movHorizontal * valores.velocidade, rb2D.velocity.y);
    }
    public void MovBasica()
    {
        Vector2 normalizacao = new Vector2(movHorizontal, movVertical).normalized;
        rb2D.velocity = normalizacao * valores.velocidade;
    }

    public void MovBorda()
    {
        if(movHorizontal != 0 && movVertical != 0)
        {
            movHorizontal = 0f;
        }
        if (tocandoBaixo)
        {
            if(!tocandoEsquerda && !tocandoDireita)
            {
                movVertical = -1;
            }    
        }
        else if(tocandoEsquerda)
        {
            if (!tocandoCima)
            {
                movHorizontal = -1;
            }
        }

        else if(tocandoDireita)
        {
            if(!tocandoCima)
            {
                movHorizontal = 1;
            }
        }

        else if(tocandoCima)
        {            
            movVertical = 1;
            //rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        Vector2 aux = new Vector2(movHorizontal, movVertical);
        rb2D.velocity = aux * valores.velocidade;
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
            valores.DiminuirVida(1);
        }
    }
}
