using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atirador", menuName = "Inimigo/Atirador/Atirador com canhoes", order = 3)]
public class Atirar2DirecoesCanhoes : Atirador2Direcoes
{
    public CanhoesLaterais canhao2;
    public override void ConfiguracoesEstado()
    {
        base.ConfiguracoesEstado();
        canhao2.Criar();
    }

    public override void Limpar()
    {
        base.Limpar();
        atacar = null;
        canhao2.Destruir();
    }
}
