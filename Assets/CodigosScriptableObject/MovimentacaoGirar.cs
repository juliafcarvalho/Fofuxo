using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovimentacaoGirar", menuName = "Movimentacao/Movimentacao girar", order = 3)]
public class MovimentacaoGirar : Movimentacao
{
    public override void Mover()
    {
        _objeto.transform.Rotate(new Vector3(0, 0, velocidade) * Time.deltaTime);
    }

    public override void ResetPosition()
    {
        _objeto.transform.position = new Vector3(0, 0, 0);
    }
}
