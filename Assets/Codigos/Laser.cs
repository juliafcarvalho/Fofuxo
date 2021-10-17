using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector2 direcao;
    void Start()
    {
        StartCoroutine(MovLaser());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direcao * Time.deltaTime);
    }

    IEnumerator MovLaser()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f);
            if(direcao.x != 0)
            {
                direcao.x *= -1;
            }

            if (direcao.y != 0)
            {
                direcao.y *= -1;
            }

        }
        
    }

    public void SeDestruir()
    {
        Destroy(this.gameObject);
    }
}
