using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] //en vez de public para los objetos.
    GameObject ModeloBala;
    GameObject drone;
    public float smoothTime;
    Vector3 velocity = Vector3.zero;
    int count = 0;
    GameObject lArm;
    GameObject rArm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Bala2()
    {
        //GameObject bala2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject bala2 = Instantiate(ModeloBala);
        //bala2.transform.parent = drone.transform;
        //bala2.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        bala2.transform.position = lArm.transform.position + new Vector3(0,0,0.8f);
        //Rigidbody balaRB2 = bala2.AddComponent<Rigidbody>();
        float thrust = 80f;
        bala2.GetComponent<Rigidbody>().AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    void Bala3()
    {
        //GameObject bala3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject bala3 = Instantiate(ModeloBala);
        //bala3.transform.parent = drone.transform;
        //bala3.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        bala3.transform.position = rArm.transform.position + new Vector3(0, 0, 0.8f);
        //Rigidbody balaRB3 = bala3.AddComponent<Rigidbody>();
        float thrust = 80f;
        bala3.GetComponent<Rigidbody>().AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    void Start()
    {
        smoothTime = 0.3f;

        drone = new GameObject(); //equivalente a Empty Game Object
        drone.name = "Drone2";

        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        body.name = "Body";
        body.transform.parent = drone.transform;

        lArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lArm.name = "Left_Arm";
        lArm.transform.position = new Vector3(-0.6f, 0f, 0f);
        lArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        lArm.transform.parent = drone.transform;

        rArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rArm.name = "Right_Arm";
        rArm.transform.position = new Vector3(0.6f, 0f, 0f);
        rArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        rArm.transform.parent = drone.transform;

        drone.transform.position = new Vector3(0, 1, -5);
    }

    // Update is called once per frame
    void Update()
    {
                    // Define a target position above and behind the target transform
        //Vector3 targetPosition = new Vector3(Random.Range(-1f,1f), 1, -5);
                    // Smoothly move the camera towards that target position
        //drone.transform.position = Vector3.SmoothDamp(drone.transform.position, targetPosition, ref velocity, smoothTime);

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 p = drone.transform.position;
            p.x -= 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 p = drone.transform.position;
            p.z -= 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 p = drone.transform.position;
            p.z += 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 p = drone.transform.position;
            p.x += 0.01f;
            drone.transform.position = p;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count % 2 == 0)
            {
                Bala2();
                count += 1;
            }
            else
            {
                Bala3();
                count += 1;
            }
        }
    }
}