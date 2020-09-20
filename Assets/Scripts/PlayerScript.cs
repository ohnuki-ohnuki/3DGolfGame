using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Plane plane;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody rb;
    public Text shotsText;
    private int shots;

    void UpdateShotsCount()
    {
        shotsText.text = shots.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(Vector3.up,Vector3.zero);
        rb = GetComponent<Rigidbody>();
        shots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        float distance;
        if (Input.GetMouseButtonDown(0))
        {
            if (plane.Raycast(ray,out distance))
            {
            startPoint = ray.GetPoint(distance);
            //   Debug.Log(ray.GetPoint(distance));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(plane.Raycast(ray,out distance))
            {
                 endPoint = ray.GetPoint(distance);
            //   Debug.Log(ray.GetPoint(distance));
            rb.AddForce(-1f * (endPoint-startPoint), ForceMode.Impulse);
            shots++;
            UpdateShotsCount();
            }
        }
    }
}
