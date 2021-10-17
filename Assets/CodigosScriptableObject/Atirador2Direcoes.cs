using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atirador", menuName = "Inimigo/Atirador/DuasDirecoes", order = 2)]
public class Atirador2Direcoes : Atirador
{
    
    public override IEnumerator _Atacar()
    {
        while (true)
        {
            GameObject projetil1 = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);
            projetil1.GetComponent<Rigidbody2D>().velocity = _objeto.transform.right * 5f;

            GameObject projetil2 = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);
            projetil2.GetComponent<Rigidbody2D>().velocity = -_objeto.transform.right * 5f;

            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }
}
