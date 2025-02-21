using UnityEngine;

public class Robot : MonoBehaviour
{
    GameObject drone;
    public float smoothTime;
    private Vector3 velocity;
    int shot;
    GameObject rArm;
    GameObject lArm;
    void BalaDerecha()
    {
        GameObject bala = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bala.transform.localScale = new Vector3(0.2f, 0.25f, 0.2f);
        bala.transform.position = rArm.transform.position;
        Rigidbody balaRB = bala.AddComponent<Rigidbody>();
        float thrust = 100.0f;
        balaRB.AddForce(0, 0, thrust, ForceMode.Impulse);
    }
    void BalaIzquierda()
    {
        GameObject bala = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bala.transform.localScale = new Vector3(0.2f, 0.25f, 0.2f);
        bala.transform.position = lArm.transform.position;
        Rigidbody balaRB = bala.AddComponent<Rigidbody>();
        float thrust = 100.0f;
        balaRB.AddForce(0, 0, thrust, ForceMode.Impulse);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shot = 0;
        smoothTime = 3.0f;
        velocity = Vector3.zero;

        drone = new GameObject();
        drone.name = "DRONE";

        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        body.name = "BODY";
        body.transform.parent = drone.transform;

        lArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lArm.name = "LARM";
        lArm.transform.position = new Vector3(-0.6f, 0, 0f);
        lArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        lArm.transform.parent = drone.transform;

        rArm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rArm.name = "RARM";
        rArm.transform.position = new Vector3(0.6f, 0, 0f);
        rArm.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        rArm.transform.parent = drone.transform;

        drone.transform.position = new Vector3(5f, 1f, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(Random.Range(2.0f, 8.0f), 1f, -5f);        

        drone.transform.position = Vector3.SmoothDamp(
            drone.transform.position,
            target,
            ref velocity,
            smoothTime);

        if(Input.GetKey(KeyCode.A))
        {
            Vector3 p = drone.transform.position;
            p.x -= 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 p = drone.transform.position;
            p.x += 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 p = drone.transform.position;
            p.z += 0.01f;
            drone.transform.position = p;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 p = drone.transform.position;
            p.z -= 0.01f;
            drone.transform.position = p;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shot % 2 == 0)
            {
                BalaDerecha();
                shot++;
            }
            else
            {
                BalaIzquierda();
                shot++;
            }
        }

    }
}
