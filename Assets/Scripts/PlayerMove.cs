using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController ccon;

    [SerializeField]
    private float speed = 0.1f;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        ccon = GetComponent<CharacterController>();
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isGamer)
        {
            ccon.Move(transform.rotation * new Vector3(speed * Input.GetAxis("Horizontal"), 0, speed * Input.GetAxis("Vertical")));
        }
    }
}
