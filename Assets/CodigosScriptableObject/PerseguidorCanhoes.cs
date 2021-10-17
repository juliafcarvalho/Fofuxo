using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perseguidor", menuName = "Perseguidor com 3 canhoes", order = 3)]
public class PerseguidorCanhoes : Comportamento
{
    public CanhoesLaterais canhao3;

    public override void AcabarEstado()
    {
        base.AcabarEstado();
        canhao3.Destruir();
        canhao3.Criar();
    }
    /*public override void ConfiguracoesEstado()
    {
        base.ConfiguracoesEstado();
        canhoes.Criar();
    }
    */
    public override void Limpar()
    {
        base.Limpar();
        canhao3.Destruir();
    }
}
