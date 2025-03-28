using UnityEngine;

public class Choque : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ouch!");
            ps.gameObject.SetActive(true);
        }
    }
}
