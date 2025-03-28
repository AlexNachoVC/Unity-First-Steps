using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using System.Collections;
using UnityEngine.Networking;

public class controlador : MonoBehaviour
{
    public TMP_InputField grupo;
    public TMP_InputField lista;
    public TMP_InputField pin;
    public GameObject Panel_de_menu;
    public GameObject Panel_de_ayuda;
    public GameObject Panel_de_niveles;

    void Start()
    {
        //CAMBIO DE ANIMACION1 A ANIMACION2
        if (SceneManager.GetActiveScene().name == "ANIMACION1")
        {
            StartCoroutine(CambiarAAnimacion2(3f));
        }

        //CAMBIO DE ANIMACION2 A NIVEL1
        if (SceneManager.GetActiveScene().name == "ANIMACION2")
        {
            StartCoroutine(CambiarANivel1(3f));
        }

        //CAMBIO DE NIVEL1 A ANIMACION3
        if (SceneManager.GetActiveScene().name == "NIVEL1")
        {
            StartCoroutine(CambiarAAnimacion3(50f));
        }

        //CAMBIO DE ANIMACION3 A NIVEL2
        if (SceneManager.GetActiveScene().name == "ANIMACION3")
        {
            StartCoroutine(CambiarANivel2(3f));
        }

        //CAMBIO DE NIVEL2 A ANIMACION4
        if (SceneManager.GetActiveScene().name == "NIVEL2")
        {
            StartCoroutine(CambiarAAnimacion4(50f));
        }

        //CAMBIO DE ANIMACION4 A ANIMACION5
        if (SceneManager.GetActiveScene().name == "ANIMACION4")
        {
            StartCoroutine(CambiarAAnimacion5(3f));
        }

        //CAMBIO DE ANIMACION5 A NIVEL3
        if (SceneManager.GetActiveScene().name == "ANIMACION5")
        {
            StartCoroutine(CambiarANivel3(3f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AskForLogin()
    {
        Usuario u = new Usuario();
        u.n_lista = lista.text; // No es necesario convertir, ya es string
        u.grupo = grupo.text;
        u.pin = pin.text;

        string jsonData = JsonUtility.ToJson(u);

        using (UnityWebRequest www = new UnityWebRequest("http://10.48.228.210/api/loginJuego", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text); // Mostrar el mensaje de error completo
            }
            else
            {
                string txt = www.downloadHandler.text;
                if (txt == "true")
                {
                    SceneManager.LoadScene("INICIO");
                }
                else
                {
                    Debug.Log("Alguno de los datos está incorrecto");
                }
                Debug.Log(txt);
            }
        }
    }






    public void VamosAJugar()
    {
        if (grupo.text.All(char.IsLetterOrDigit) && grupo.text.Length == 2)
        {
            if (lista.text.All(char.IsNumber) && lista.text.Length > 0)
            {
                StartCoroutine(AskForLogin());
            }
            else Debug.Log("No pasa por el número de lista");
        }
        else Debug.Log("No pasa por el grupo");
    }

    public void Empezar()
    {
        Debug.Log("en funcion");

        SceneManager.LoadScene("ANIMACION1");
    }

    public void Niveles()
    {
        Panel_de_niveles.SetActive(true);
    }
    public void OcultarNiveles()
    {
        Panel_de_niveles.SetActive(false);
    }

    public void ANIMACION1()
    {
        SceneManager.LoadScene("ANIMACION1");
    }
    public void ANIMACION3()
    {
        SceneManager.LoadScene("ANIMACION3");
    }
    public void ANIMACION4()
    {
        SceneManager.LoadScene("ANIMACION4");
    }

    public void MostrarMenu()
    {
        Panel_de_menu.SetActive(true);
    }
    public void OcultarMenu()
    {
        Panel_de_menu.SetActive(false);
    }
    public void MostrarAyuda()
    {
        Panel_de_ayuda.SetActive(true);
    }
    public void OcultarAyuda()
    {
        Panel_de_ayuda.SetActive(false);
    }
    public void Inicio()
    {
        SceneManager.LoadScene("INICIO");
    }

    IEnumerator CambiarAAnimacion2(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("ANIMACION2");
    }

    IEnumerator CambiarANivel1(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("NIVEL1");
    }

    IEnumerator CambiarAAnimacion3(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("ANIMACION3");
    }
    IEnumerator CambiarANivel2(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("NIVEL2");
    }

    IEnumerator CambiarANivel3(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("NIVEL3");
    }

    IEnumerator CambiarAAnimacion4(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("ANIMACION4");
    }
    IEnumerator CambiarAAnimacion5(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("ANIMACION5");
    }


}
