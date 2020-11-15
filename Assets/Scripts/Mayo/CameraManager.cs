using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField][Range(0, 0.5f)] private float horizontalMovementZone = .25f;
    [SerializeField] [Range(0, 0.5f)] private float verticalMovementZone = .25f;
    [SerializeField] private float horizontalBoundingBox = 5f;
    [SerializeField] private float verticalBoundingBox = 5f;
    [SerializeField] private float cameraMovementSpeed = 10f;
    [SerializeField] private float cameraZoomSpeed = 10f;
    public bool shouldMove = true;
    private Vector2 initialPosition;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero;
        float horizontalBoundary = horizontalMovementZone * Screen.width;
        float verticalBoundary = verticalMovementZone* Screen.height;
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

        if (shouldMove)
        {
            transform.Translate(direction * cameraMovementSpeed * Time.deltaTime);
            if (transform.position.x - initialPosition.x < - horizontalBoundingBox || transform.position.x - initialPosition.x > horizontalBoundingBox || transform.position.y - initialPosition.y < -verticalBoundingBox || transform.position.y - initialPosition.y > verticalBoundingBox)
            {
                transform.Translate(-direction * cameraMovementSpeed * Time.deltaTime);
            }
        }
        camera.orthographicSize += -Input.mouseScrollDelta.y * cameraZoomSpeed * Time.deltaTime;
    }

}