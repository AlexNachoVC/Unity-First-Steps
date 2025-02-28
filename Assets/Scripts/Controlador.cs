using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class Controlador : MonoBehaviour
{
    public TMP_InputField grupo;
    public TMP_InputField lista;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VamosAJugar()
    {
        if (grupo.text.All(char.IsLetterOrDigit) && grupo.text.Length == 2)
        {
            if (lista.text.All(char.IsNumber) && lista.text.Length > 0)
            {
                SceneManager.LoadScene("Logic");
            }
            else Debug.Log("No pasa por el número de lista");
        }
        else Debug.Log("No pasa por el grupo");
    }
}
