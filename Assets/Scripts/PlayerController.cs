using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AmmoController _ammoController;
    GameOver _gameOver;
    SpriteRenderer _spriteRenderer;
    LineRenderer _lineRenderer;
    Vector2 _currentPosition;
    public Rigidbody2D playerRigidbody2D;
    public Vector2 playerStartPosition;
    [SerializeField] float _launchPower = 1000;
    [SerializeField] float _maxDragDistance = 4f;

    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        _gameOver = FindObjectOfType<GameOver>();
        _ammoController = FindObjectOfType<AmmoController>();
        playerStartPosition = playerRigidbody2D.position;
        playerRigidbody2D.isKinematic = true; //prevents player object from moving
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        LineRendererAimer();
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
        _currentPosition = playerRigidbody2D.position; //gets the current position of the player object
        Vector2 direction = playerStartPosition - _currentPosition; //determines which directions to send the object
        direction.Normalize(); //keeps the same direction but its length is 1.0.
        playerRigidbody2D.isKinematic = false; //allows object to move again
        playerRigidbody2D.AddForce(direction * _launchPower); //pushes object in opposite direction of the mouse multiplied by the _launchPower
        _lineRenderer.enabled = false; //removes the line renderer(arrows) upon release of mouse
        _ammoController.AmmoCounter(); //removes 1 ammo
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, playerStartPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - playerStartPosition;
            direction.Normalize();
            desiredPosition = playerStartPosition + (direction * _maxDragDistance);//makes the clamping more of a circular distance instead of a wall
        }

        if (desiredPosition.x > playerStartPosition.x)
        {
            desiredPosition.x = playerStartPosition.x; //clamps the object so player can not drag to the right
        }

        playerRigidbody2D.position = desiredPosition;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(ResetAfterDelay());
        
        if(other.gameObject.tag =="DeathObstacles")
        {
            _gameOver.EndGame();
        }
    }

    void LineRendererAimer()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, playerStartPosition);
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        playerRigidbody2D.position = playerStartPosition;
        playerRigidbody2D.isKinematic = true;
        playerRigidbody2D.velocity = Vector2.zero;
    }
}
