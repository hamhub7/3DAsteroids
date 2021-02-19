using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 5;

    [SerializeField]
    private MeshRenderer model;

    private int health;

    private GameManager manager;

    private bool collisionEnabled = true;

    // Start is called before the first frame update
    private void Start()
    {
        health = 5;
        manager = FindObjectOfType<GameManager>();
        model = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collisionEnabled) return;

        if (!collision.gameObject.CompareTag("Asteroid")) return;

        health--;
        if(health <= 0)
        {
            model.enabled = false;
            manager.EndGame();
        }

        StartCollisionCoroutine();
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

    public int GetHealth()
    {
        return health;
    }
}
