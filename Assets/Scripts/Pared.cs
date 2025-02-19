using UnityEngine;

public class Pared : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Suelo()
    {

    }

    void Tabique()
    {
        GameObject tab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tab.transform.localScale = new Vector3(1.0f, 0.5f, 0.5f);
        MeshRenderer mr = tab.GetComponent<MeshRenderer>();
        mr.material.color = new Color(0.97f, 0.51f, 0);
        Rigidbody tabRB = tab.AddComponent<Rigidbody>();
        tabRB.mass = 1.0f;
    }

    void Start()
    {
        Tabique();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
