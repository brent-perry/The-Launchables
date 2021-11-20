using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{

    // [SerializeField] ParticleSystem _particleSystem;
    // [SerializeField] Sprite _deadEnemy;
    bool _hasDied;
   
    void OnCollisionEnter2D(Collision2D other)
    {
        //checks if player is in level and then if collides with anything
        if (ShouldDieFromCollision(other))
        {
            StartCoroutine(Die());
        }

        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        Enemy enemy = other.collider.GetComponent<Enemy>();
        //checks if collides with other enemies and does nothing
        if (enemy != null)
        {
            return;
        }

        bool ShouldDieFromCollision(Collision2D collision)
        {
            if (_hasDied)
            {
                return false;
            }

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                return true;
            }

            //checks if objects/player have collided with enemy and if desired angle(top) is successful
            if (other.contacts[0].normal.y < -0.5)
            {
                return true;
            }

            return false;
        }

        IEnumerator Die()
        {
            _hasDied = true;
            // GetComponent<SpriteRenderer>().sprite = _deadEnemy;
            // _particleSystem.Play();
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
        }
    }
}
