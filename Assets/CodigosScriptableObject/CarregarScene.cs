using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CarregarScene", menuName = "CarregarScene", order = 1)]
public class CarregarScene : ScriptableObject
{
    public void IrParaScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
