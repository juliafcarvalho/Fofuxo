using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSimples : MonoBehaviour
{
    public bool estouNoCaminho;
    public Vector2 ultimaPos;
    public CarregarScene carregamento;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ultimaPos = this.transform.position;
            transform.Translate(0, 0.2f, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ultimaPos = this.transform.position;
            transform.Translate(0, -0.2f, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ultimaPos = this.transform.position;
            transform.Translate(-0.2f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ultimaPos = this.transform.position;
            transform.Translate(0.2f, 0, 0);
        }
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
