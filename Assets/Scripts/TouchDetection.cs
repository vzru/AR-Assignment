using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    var red = Random.Range(0.0f, 1.0f);
                    var blue = Random.Range(0.0f, 1.0f);
                    var green = Random.Range(0.0f, 1.0f);
                    var newColor = new Color(red, green, blue);
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    Debug.Log("HIT");

                }
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    var red = Random.Range(0.0f, 1.0f);
                    var blue = Random.Range(0.0f, 1.0f);
                    var green = Random.Range(0.0f, 1.0f);
                    var newColor = new Color(red, green, blue);
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    Debug.Log("HIT");

                }
            }
        }

#endif

    }
}
