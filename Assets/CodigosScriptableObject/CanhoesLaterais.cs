using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CanhoesLaterais", menuName = "CanhoesLaterais", order = 1)]
public class CanhoesLaterais : ScriptableObject
{
    public GameObject prefabCanhao;
    public List<GameObject> canhoesCriados = new List<GameObject>();
    public virtual void Criar()
    {
        canhoesCriados.Clear();
        GameObject canhao1 = Instantiate(prefabCanhao, new Vector3(-31.3f, 0.28f, 0), Quaternion.identity);
        canhao1.GetComponent<Laser>().direcao = new Vector2(0, 5);
        canhoesCriados.Add(canhao1);
        GameObject canhao2 = Instantiate(prefabCanhao, new Vector3(31.3f, 0.28f, 0), Quaternion.identity);
        canhao2.GetComponent<Laser>().direcao = new Vector2(0,-5);
        canhao2.transform.localScale = new Vector3(-1, 1, 1);
        canhoesCriados.Add(canhao2);
    }

    public virtual void Destruir()
    {
        for(int i = 0; i < canhoesCriados.Count; i++)
        {
            if(canhoesCriados[i] != null)
            canhoesCriados[i].GetComponent<Laser>().SeDestruir();          
        }
        canhoesCriados.Clear();
    }
}
