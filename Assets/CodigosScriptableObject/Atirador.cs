using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atirador", menuName = "Inimigo/Atirador", order = 2)]
public class Atirador : Comportamento
{
    Coroutine atacar;
    public GameObject projetil;
    public GameObject coletavel;
    public float tempoAtirar = 1;
    public int coletasNecessarias = 3;
    int coletados = 0;
     
    public override void Atacar()
{
        if (atacar == null)
            atacar = _objeto.GetComponent<InimigoBase>().StartCoroutine(_Atacar());
    }

    public IEnumerator _Atacar()
    {
        while (true)
        {
            GameObject aux = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);

            Vector3 targ = Jogador.jogador.transform.position;
            targ.z = 0f;
            Vector3 objectPos = aux.transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;
            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            aux.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            aux.GetComponent<Rigidbody2D>().velocity = aux.transform.right * 5f;
            Destroy(aux.gameObject, 2f);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
        atacar = null;
    }

    public override void ConfiguracoesEstado()
    {
        _objeto.transform.position = new Vector3(0, 0, 0);
        CriarColetavel();
    }

    public void Coletei()
    {
        coletados++;
        if(coletados < coletasNecessarias)
        {
            CriarColetavel();
        }        
    }
    public void CriarColetavel()
    {
        int aux = Random.Range(0, 4); //0 - tocandoEsquerda, 1 - tocandoDireita, 2 - tocandoCima e 3 - tocandoBaixo
        float pos;
        GameObject criacao = new GameObject();

        switch (aux)
        {
            case 0:
                pos = Random.Range(10f, -10f);
                criacao = Instantiate(coletavel, new Vector2(-13, pos), Quaternion.identity);
                break;
            case 1:
                pos = Random.Range(10f, -10f);
                criacao = Instantiate(coletavel, new Vector2(12, pos), Quaternion.identity);
                break;
            case 2:
                pos = Random.Range(-12.5f, -12.5f);
                criacao = Instantiate(coletavel, new Vector2(pos, 10.5f), Quaternion.identity);
                break;
            case 3:
                pos = Random.Range(-12.5f, -12.5f);
                criacao = Instantiate(coletavel, new Vector2(pos, -10.8f), Quaternion.identity);
                break;
        }

        criacao.GetComponent<Coletavel>().inimigo = this;
    }
    public override void AcabarEstado()
    {
        if(atacar != null)
        {
            _objeto.StopCoroutine(atacar);            
        }
        Limpar();
    }

    public override void Limpar()
    {
        atacar = null;
        coletados = 0;
    }

    public override bool Atingiu()
    {
        if (coletados >= coletasNecessarias)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
