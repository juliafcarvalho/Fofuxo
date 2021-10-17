using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float direcao = 5;
    void Start()
    {
        StartCoroutine(MovLaser());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0,direcao) * Time.deltaTime);
    }

    IEnumerator MovLaser()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f);
            direcao *= -1;
        }
        
    }
}
