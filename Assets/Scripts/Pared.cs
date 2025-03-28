using UnityEngine;

public class Pared : MonoBehaviour
{

    //Crear tabique con medidas (1,0.5,0.5) centrado en el origen, naranja.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Suelo()
    {
        GameObject suelo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        suelo.transform.localScale = new Vector3(30.0f, 0.1f, 10.0f);
        suelo.transform.position = new Vector3(0, -0.3f, 0);
        Rigidbody sueloRB = suelo.AddComponent<Rigidbody>();
        sueloRB.mass = 10000.0f;
        sueloRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Tabique(float x,float y)
    {
        GameObject tabique = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tabique.name = "Tabique";
        tabique.transform.localScale = new Vector3(1.0f, 0.5f, 0.5f);
        tabique.transform.position = new Vector3(x, y, 0);
        MeshRenderer mr = tabique.GetComponent<MeshRenderer>();
        mr.material.color = new Color(0.97f, 0.51f, 0);
        Rigidbody tabiqueRB = tabique.AddComponent<Rigidbody>();
        tabiqueRB.mass = 5;
    }

    void Bala()
    {
        GameObject bala = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bala.transform.localScale = new Vector3(1f, 0.5f, 1f);
        bala.transform.position = new Vector3(5f, 0.5f, -10.0f);
        Rigidbody balaRB = bala.AddComponent<Rigidbody>();
        float thrust = 83.0f;
        balaRB.AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    void Bala2()
    {
        GameObject bala2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bala2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bala2.transform.position = new Vector3(5f, 0.5f, -10.0f);
        Rigidbody balaRB2 = bala2.AddComponent<Rigidbody>();
        float thrust = 100f;
        balaRB2.AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    void Start()
    {
        Suelo();
        for (float j = 0; j < 2; j += 0.5f)
        {
            if (j % 1 == 0)
            {
                for (float i = 0; i < 10; i += 1f)
                {
                    Tabique(i, j);
                }
            }
            else
            {
                for (float i = 0.5f; i < 9; i+= 1f)
                {
                    Tabique(i, j);
                }
            }
        }
        //Bala2(); 
    }


    // Update is called once per frame
    void Update()
    {
        //Para pintar una linea, donde comenzar, donde terminar, color.
        Debug.DrawLine(Vector3.zero, new Vector3(10, 0, 0), Color.red);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 10, 0), Color.green);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 0, 10), Color.blue);
        //Solamente se ven en el tab de "Scene" y no en el de "Game" porque es Debug.
    }
}
