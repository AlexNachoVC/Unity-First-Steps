using UnityEngine;
[RequireComponent(typeof(MeshCollider))]
public class ClickAndDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDown()
    {
        Vector3 pos = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(pos);
        Debug.Log("Touched" + gameObject.name + " at " + screenPoint);

        Vector3 mousePos = new Vector3(Input.mousePosition.x,
                                       Input.mousePosition.y,
                                       screenPoint.z);
        offset = pos - Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x,
                                       Input.mousePosition.y,
                                       screenPoint.z);
        Vector3 currPosition = Camera.main.ScreenToWorldPoint(mousePos) + offset;
        transform.position = currPosition;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
