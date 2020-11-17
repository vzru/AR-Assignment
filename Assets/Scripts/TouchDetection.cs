using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public Animator anim;

    bool exploded;
    // Start is called before the first frame update
    void Start()
    {
        exploded = false;
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

                    Debug.Log("HIT");
                }
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Ray Casted");
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //var red = Random.Range(0.0f, 1.0f);
                    //var blue = Random.Range(0.0f, 1.0f);
                    //var green = Random.Range(0.0f, 1.0f);
                    //var newColor = new Color(red, green, blue);
                    //hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    exploded = !exploded;
                    if (exploded)
                    {
                        anim.SetBool("Exploded", true);
                    }
                    else
                    {
                        anim.SetBool("Exploded", false);
                    }
                    Debug.Log("HIT");

                }
            }
        }

        //if (Input.GetKey(KeyCode.E))
        //{
        //    GetComponent<Animator>().SetBool("Exploded", true);
        //}

        //if (Input.GetKey(KeyCode.U))
        //{
        //    GetComponent<Animator>().SetBool("Exploded", false);
        //}
#endif

    }
}
