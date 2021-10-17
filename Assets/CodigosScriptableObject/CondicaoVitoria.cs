using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicaoVitoria : ScriptableObject
{
    public virtual bool Atingiu()
    {
        return false;
    }

    public virtual void Zerar() { }

    public virtual void Acao() { }

    public virtual void Configurar() { }
}
