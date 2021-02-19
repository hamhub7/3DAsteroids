using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    private GameManager manager;

    public int size = 3;

    private bool collisionEnabled = true;

    private void Awake()
    {
        int norm = Mathf.Min(3, Mathf.Max(0, size)); // Clamp for error reasons
        float scale = 0;
        switch(norm)
        {
            case 1:
                scale = 5f;
                break;
            case 2:
                scale = 10f;
                break;
            case 3:
                scale = 20f;
                break;
        }

        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collisionEnabled) return;

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet")) return;

        if(collision.gameObject.CompareTag("Bullet"))
        {
            manager.score += 1000;
        }

        if (size > 1)
        {
            GameObject sphere1 = Instantiate(gameObject, transform.position + Vector3.up, Quaternion.identity);
            AsteroidScript script1 = sphere1.GetComponent<AsteroidScript>();
            script1.size = size - 1;
            sphere1.GetComponent<Rigidbody>().velocity = manager.sphereSpeed * (manager.player.transform.position - sphere1.transform.position).normalized;
            script1.StartCollisionCoroutine();
            GameObject sphere2 = Instantiate(gameObject, transform.position + Vector3.down, Quaternion.identity);
            AsteroidScript script2 = sphere1.GetComponent<AsteroidScript>();
            script2.size = size - 1;
            sphere2.GetComponent<Rigidbody>().velocity = manager.sphereSpeed * (manager.player.transform.position - sphere2.transform.position).normalized;
            script2.StartCollisionCoroutine();
        }

        Destroy(gameObject);
    }

    public void StartCollisionCoroutine()
    {
        IEnumerator cor = BlinkCollision();
        StartCoroutine(cor);
    }

    IEnumerator BlinkCollision()
    {
        collisionEnabled = false;
        yield return new WaitForSeconds(2f);
        collisionEnabled = true;
    }
}
