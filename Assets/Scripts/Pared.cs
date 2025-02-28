using UnityEngine;

public class Pared : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.localScale = new Vector3(30.0f, 0.1f, 10.0f);
        suelo.transform.position = new Vector3(0, -0.3f, 0);
        Rigidbody sueloRB = suelo.AddComponent<Rigidbody>();
        sueloRB.mass = 1000.0f;
        sueloRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Tabique(Vector3 pos)
    {
        GameObject tab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tab.transform.localScale = new Vector3(1.0f, 0.5f, 0.5f);
        tab.transform.position = pos;
        MeshRenderer mr = tab.GetComponent<MeshRenderer>();
        mr.material.color = new Color(0.97f, 0.51f, 0);
        Rigidbody tabRB = tab.AddComponent<Rigidbody>();
        tabRB.mass = 0.1f;
    }

    void Bala()
    {
        GameObject bala = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bala.transform.localScale = new Vector3(1f, 0.5f, 1f);
        bala.transform.position = new Vector3(5f, 1f, -5.0f);
        Rigidbody balaRB = bala.AddComponent<Rigidbody>();
        float thrust = 10.0f;
        balaRB.AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    void Start()
    {
        Suelo();
        float x = 0, y = 0, z = 0;


        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0) 
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    Tabique(pos);
                    x += 1;
                }
                x = 0;
                y += 0.5f;
            }
            else
            {
                for (int j = 0; j < 9; j++)
                {
                    Vector3 pos = new Vector3(x + 0.5f, y, z);
                    Tabique(pos);
                    x += 1;
                }
                x = 0;
                y += 0.5f;
            }
        }
        // Bala();
    }

    // Update is called once per frame
    void Update()
    {
        // donde comenzar, donde terminar, color
        Debug.DrawLine(Vector3.zero, new Vector3(10, 0, 0), Color.red);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 10, 0), Color.green);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 0, 10), Color.blue);
        // Solamente se ven en el tab de "Scene" no en el de "Game"
    }
}
