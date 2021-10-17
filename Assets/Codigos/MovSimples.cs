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
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
                carregamento.IrParaScene(int.Parse(collision.name));
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
