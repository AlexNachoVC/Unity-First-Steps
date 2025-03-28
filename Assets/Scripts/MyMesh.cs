using UnityEngine;

public class MyMesh : MonoBehaviour
{
    public Material theBricks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            mySphere.name = "LaEsferita" + i;
            mySphere.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(8, 12), Random.Range(-5, 5));
            mySphere.transform.localScale = new Vector3(1, 1, 1);
            MeshRenderer mr = mySphere.GetComponent<MeshRenderer>();
            mr.material = new Material(theBricks);
            mr.material.color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Rigidbody rb = mySphere.AddComponent<Rigidbody>();
            rb.mass = 1.0f; //1kg
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
