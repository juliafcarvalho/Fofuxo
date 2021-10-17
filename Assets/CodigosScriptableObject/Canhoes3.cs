using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "3 canhoes", menuName = "3 canhoes", order = 1)]
public class Canhoes3 : CanhoesLaterais
{
    public override void Criar()
    {
        base.Criar();
        GameObject canhao3 = Instantiate(prefabCanhao, new Vector3(-11, -34.1f, 0), Quaternion.identity);
        canhao3.GetComponent<Laser>().direcao = new Vector2(0, -5);
        canhao3.transform.eulerAngles = new Vector3(0, 0, 90);
        canhoesCriados.Add(canhao3);
    }

    public override void Destruir()
    {
        base.Destruir();
    }
}
