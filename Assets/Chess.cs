using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    int children;
    int startPoint = 0;
    int activeIndex;

    [SerializeField] GameObject particleVFX;
    private Animator animator;

    [System.Obsolete]
    void Start()
    {
        animator = GetComponent<Animator>();
        children = transform.GetChildCount();
        DeActiveAllChildGameobject();
    }

    void Update()
    {

    }

    private void OnMouseOver()
    {
        activeIndex = Random.Range(0, children);
        transform.GetChild(activeIndex).gameObject.SetActive(true);
        startPoint += 1;

        if (startPoint == children)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }


    private void DeActiveAllChildGameobject()
    {
        for (int i = 0; i < children; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private IEnumerator ExampleCoroutine()
    {
        animator.SetTrigger("Scale");

        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSeconds(.5f);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].chesses.Remove(this);
        GameObject explosion = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(explosion, .75f);
        Destroy(gameObject);
    }
}
