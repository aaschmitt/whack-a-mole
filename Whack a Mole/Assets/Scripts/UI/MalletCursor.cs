using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletCursor : MonoBehaviour
{
    [SerializeField] private float rotationWhenClicked = 90f;

    private float _normalRotation = 0.0f;
    void Start()
    {
        _normalRotation = transform.eulerAngles.z;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }

    void OnEnable()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationWhenClicked);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _normalRotation);
        }
    }
}
