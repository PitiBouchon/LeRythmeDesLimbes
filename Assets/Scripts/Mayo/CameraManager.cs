using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField][Range(0, 0.5f)] private float horizontalBox = .25f;
    [SerializeField] [Range(0, 0.5f)] private float verticalBox = .25f;
    [SerializeField] private float cameraMovementSpeed = 1f;
    [SerializeField] private float cameraZoomSpeed = 1f;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero;
        float horizontalBoundary = horizontalBox * Screen.width;
        float verticalBoundary = verticalBox* Screen.height;
        if (Input.mousePosition.x < horizontalBoundary)
        {
            direction += Vector2.left;
        }
        if (Input.mousePosition.x > Screen.width - horizontalBoundary)
        {
            direction += Vector2.right;
        }
        if (Input.mousePosition.y < verticalBoundary)
        {
            direction += Vector2.down;
        }
        if (Input.mousePosition.y > Screen.height - verticalBoundary)
        {
            direction += Vector2.up;
        }

        transform.Translate(direction * cameraMovementSpeed * Time.deltaTime);
        camera.orthographicSize += -Input.mouseScrollDelta.y * cameraZoomSpeed * Time.deltaTime;
    }

}
