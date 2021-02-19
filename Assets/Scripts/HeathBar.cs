using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBar : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hearts = new GameObject[5];

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 5; i++)
        {
            if(i < playerHealth.GetHealth())
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
