using UnityEngine;
using System.Collections.Generic;

public class visual : MonoBehaviour
{
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.localScale = new Vector3(30.0f, 0.1f, 10.0f);
        suelo.transform.position = new Vector3(0, -0.3f, 0);
        Rigidbody sueloRB = suelo.AddComponent<Rigidbody>();
        sueloRB.mass = 10000.0f;
        sueloRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Tabique(Vector3 pos)
    {
        GameObject tabique = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tabique.name = "Tabique";
        tabique.transform.localScale = new Vector3(1.0f, 0.5f, 0.5f);
        tabique.transform.position = pos;
        MeshRenderer mr = tabique.GetComponent<MeshRenderer>();
        mr.material.color = new Color(0.97f, 0.51f, 0);
        Rigidbody tabiqueRB = tabique.AddComponent<Rigidbody>();
        tabiqueRB.mass = 5;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Suelo();
        List<int> lugares = Logic.GeneratePlaces(4);
        for (int i = 0; i < lugares.Count; i++)
        {
            if(lugares[i] == 1)
            {
                Tabique(new Vector3(i, 0, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
