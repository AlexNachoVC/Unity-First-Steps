using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using System.Collections;
using UnityEngine.Networking;

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

    IEnumerator AskForLogin()
    {
        WWWForm form = new WWWForm();

        Usuario u = new Usuario();
        u.listNumber = int.Parse(lista.text);
        u.group = grupo.text;

        form.AddField("datos", JsonUtility.ToJson(u));

        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8001/login", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string txt = www.downloadHandler.text;
                SceneManager.LoadScene("Logic");
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
}
