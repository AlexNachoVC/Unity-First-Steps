using UnityEngine;

public class MyMesh : MonoBehaviour
{
    public Material laMadera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.name = "LaEsferita";
        mySphere.transform.position = new Vector3(1, 5, -3); // 1 a la derecha, 5 arriba, 3 hacia atras
        
        MeshRenderer mr = mySphere.GetComponent<MeshRenderer>();
        // mr.material.color = Color.white;
        mr.material = laMadera;

        Rigidbody rb = mySphere.AddComponent<Rigidbody>();
        rb.mass = 1.0f; // 1 kg
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
