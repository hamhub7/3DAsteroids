using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        IEnumerator cor = DisableBullet();
        StartCoroutine(cor);
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
