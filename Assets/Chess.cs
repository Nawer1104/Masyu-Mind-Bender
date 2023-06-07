using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    int children;
    int startPoint = 0;
    int activeIndex;

    [System.Obsolete]
    void Start()
    {
        children = transform.GetChildCount();
        DeActiveAllChildGameobject();


    }

    void Update()
    {
        if (startPoint == children)
        {
            startPoint = 0;
            DeActiveAllChildGameobject();
        }
    }

    private void OnMouseDown()
    {
        activeIndex = Random.Range(0, children);
        transform.GetChild(activeIndex).gameObject.SetActive(true);
        startPoint += 1;
    }

    private void DeActiveAllChildGameobject()
    {
        for (int i = 0; i < children; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
