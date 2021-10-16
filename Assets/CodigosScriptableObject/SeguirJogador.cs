using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeguirJogador", menuName = "Inimigo/Seguir jogador", order = 1)]
public class SeguirJogador : Comportamento
{
    public Vector2 positionToMoveTo;
    Coroutine mov;
    public override void Mover(GameObject _object)
    {
        if(mov == null)
        mov = _objeto.GetComponent<InimigoBase>().StartCoroutine(LerpPosition(Jogador.jogador.transform.position, 5));
    }

    public IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = _objeto.transform.position;

        while (time < duration)
        {
            _objeto.transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _objeto.transform.position = targetPosition;
        mov = null;
    }
}