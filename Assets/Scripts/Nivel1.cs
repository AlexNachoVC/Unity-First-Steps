using UnityEngine;
using TMPro;
using System.Collections;

public class Nivel1 : MonoBehaviour
{
    public TMP_Text texto;
    public float tiempoEspera = 3f;
    public float duracionDesvanecimiento = 2f;

    void Start()
    {
        StartCoroutine(DesvanecerTextoDespuesDeTiempo());
    }

    IEnumerator DesvanecerTextoDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoEspera);
        Color colorOriginal = texto.color;
        for (float t = 0; t < 1; t += Time.deltaTime / duracionDesvanecimiento)
        {
            texto.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }
        texto.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, 0);
    }
}
