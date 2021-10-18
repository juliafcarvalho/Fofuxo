using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atirador", menuName = "Inimigo/Atirador/QuatroDirecoes", order = 3)]
public class Atirar4Direcoes : Atirador
{
    public override IEnumerator _Atacar()
    {
        while (true)
        {
            GameObject projetil1 = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);
            projetil1.GetComponent<Rigidbody2D>().velocity = _objeto.transform.up * 5f;

            GameObject projetil2 = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);
            projetil2.GetComponent<Rigidbody2D>().velocity = -_objeto.transform.up * 5f;

            GameObject projetil3 = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);
            projetil3.GetComponent<Rigidbody2D>().velocity = _objeto.transform.right * 5f;

            GameObject projetil4 = Instantiate(projetil, _objeto.transform.position, Quaternion.identity);
            projetil4.GetComponent<Rigidbody2D>().velocity = -_objeto.transform.right * 5f;

            yield return new WaitForSeconds(tempoAtirar);
        }
    }
}
