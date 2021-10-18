using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atirador", menuName = "Inimigo/Atirador/Base", order = 1)]
public class Atirador : Comportamento
{
    public Coroutine atacar;
    public GameObject projetil;    
    public float tempoAtirar = 1;
    public override void Atacar()
{
        if (atacar == null)
            atacar = _objeto.GetComponent<InimigoBase>().StartCoroutine(_Atacar());
    }

    public virtual IEnumerator _Atacar()
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
            yield return new WaitForSeconds(tempoAtirar);
        }
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
        base.Limpar();
        atacar = null;        
    }

    
}
