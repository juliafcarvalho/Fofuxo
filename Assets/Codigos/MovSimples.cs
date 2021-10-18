using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSimples : MonoBehaviour
{
    public CarregarScene carregamento;

    public Rigidbody2D rb2D;
    public float movHorizontal;

    public FasesPassadas controleFases;
    public SpriteRenderer[] portais;

    bool colidindo;
    int numero;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        controleFases.jogador = this;
        CorFase();
        this.transform.position = controleFases.ultimaPos;
    }

    public void CorFase()
    {
        for (int i = 0; i < controleFases.faseLiberada.Length; i++)
        {
            if (!controleFases.faseLiberada[i])
            {
                portais[i].color = Color.white;
            }
            else
            {
                portais[i].color = Color.black;
            }
        }
    }

    void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal");

        if(colidindo && Input.GetKeyDown(KeyCode.Space))
        {
            controleFases.faseAtual = numero;
            controleFases.ultimaPos = this.transform.position;
            carregamento.IrParSceneNOME("Chefe 0" + numero);
        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(movHorizontal * 10, 0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Int")
        {
            colidindo = true;
            numero = int.Parse(collision.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Int")
        {
            colidindo = false;
        }
    }
}
