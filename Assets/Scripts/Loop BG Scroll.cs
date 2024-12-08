using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f; // Speed of the background movement.
    [SerializeField] private bool isHorizontal = true; // Set true for horizontal scrolling, false for vertical.
    [SerializeField] private float tileSize; // The size of one tile in the scrolling direction.

    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position of the background.
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on the scroll speed and direction.
        float offset = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        if (isHorizontal)
        {
            transform.position = startPosition + Vector3.left * offset;
        }
        else
        {
            transform.position = startPosition + Vector3.down * offset;
        }
    }
}