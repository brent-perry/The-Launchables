using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    LineRenderer _lineRenderer;
    Vector2 _currentPosition;
    Vector2 _startPosition;
    [SerializeField] float _launchPower = 1000;
    [SerializeField] float _maxDragDistance = 4f;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true; //prevents player object from moving
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        LineRendererAimer();
        if (transform.position.y < -8)//checks if bird falls off the map
        {
            ResetAfterDelay();
        }
    }

    void OnMouseDown()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        //changes color of player to indicate if selected
        _spriteRenderer.color = Color.red;
        _lineRenderer.enabled = true;
    }

    void OnMouseUp()
    {
        _spriteRenderer.color = Color.white; //changes player back to original color upon release
        _currentPosition = _rigidbody2D.position; //gets the current position of the player object
        Vector2 direction = _startPosition - _currentPosition; //determines which directions to send the object
        direction.Normalize(); //keeps the same direction but its length is 1.0.
        _rigidbody2D.isKinematic = false; //allows object to move again
        _rigidbody2D.AddForce(direction * _launchPower); //pushes object in opposite direction of the mouse multiplied by the _launchPower
        _lineRenderer.enabled = false; //removes the line renderer(arrows) upon release of mouse
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        
        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);//makes the clamping more of a circular distance instead of a wall
        }

        if (desiredPosition.x > _startPosition.x)
        {
            desiredPosition.x = _startPosition.x; //clamps the object so player can not drag to the right
        }

        _rigidbody2D.position = desiredPosition;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(ResetAfterDelay());
    }

    void LineRendererAimer()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _startPosition);
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
