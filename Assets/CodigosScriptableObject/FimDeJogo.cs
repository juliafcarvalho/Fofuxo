using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeJogo : MonoBehaviour
{
    public FasesPassadas fases;
    public void TrocarScene()
    {
        fases.Iniciar();
        SceneManager.LoadScene(0);
    }
}
