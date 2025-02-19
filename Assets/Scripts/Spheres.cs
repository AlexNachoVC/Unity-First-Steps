using UnityEngine;
using System.Collections;

public class Spheres : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            mySphere.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(8.0f, 12.0f), Random.Range(-5.0f, 5.0f));

            MeshRenderer mr = mySphere.GetComponent<MeshRenderer>();
            mr.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            Rigidbody rb = mySphere.AddComponent<Rigidbody>();
            rb.mass = 1.0f; // 1 kg
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
