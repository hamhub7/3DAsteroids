using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private float sense = 5f;

    [SerializeField]
    private float yClamp = 70f;

    private float yAngle = 0f;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isGamer)
        {
            float xAngle = transform.eulerAngles.y + sense * Input.GetAxis("Mouse X");
            yAngle -= sense * Input.GetAxis("Mouse Y");
            yAngle = Mathf.Clamp(yAngle, -yClamp, yClamp);
            transform.eulerAngles = new Vector3(yAngle, xAngle, 0);
        }
    }
}
