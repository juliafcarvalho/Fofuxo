using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSimples : MonoBehaviour
{
    public bool estouNoCaminho;
    public Vector2 ultimaPos;
    public CarregarScene carregamento;

    public Rigidbody2D rb2D;
    public float movHorizontal, movVertical;

    public FasesPassadas controleFases;
    public SpriteRenderer[] portais;
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
        ultimaPos = this.transform.position;
        movHorizontal = Input.GetAxisRaw("Horizontal");
        movVertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 normalizacao = new Vector2(movHorizontal, movVertical).normalized;
        rb2D.velocity = normalizacao * 10;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Caminho")
        {
            estouNoCaminho = true;
        }
        if(collision.tag == "Int")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                controleFases.faseAtual = int.Parse(collision.name);
                controleFases.ultimaPos = this.transform.position;
                carregamento.IrParSceneNOME("Chefe 0" + collision.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Caminho")
        {            
            this.transform.position = ultimaPos;
            estouNoCaminho = false;
        }
    }
}
