using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    AudioSource collideAudioSource;

    AudioSource destroyAudioSource;

    public bool canControl;

    private int health = 10;

    private List<BoxCollider2D> colliders;
    private List<FixedJoint2D> allJoints;
    private List<Rigidbody2D> sprites;

    void Start()
    {
        canControl = true;
        var sources = GetComponents<AudioSource>();
        collideAudioSource = sources[0];
        destroyAudioSource = sources[1];

        colliders = (GetComponents<BoxCollider2D>()).ToList();
        allJoints = (GetComponents<FixedJoint2D>()).ToList();
        sprites = (GetComponentsInChildren<Rigidbody2D>()).ToList();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        canControl = false;
        transform.SetParent(GameObject.Find("CrateHolder").transform, true);
        collideAudioSource.Play();
        if (other.collider.tag == "Shot") TakeDamage(other.collider);
            
    }

    private void TakeDamage(Collider2D collider) {

        var cannonball = collider.gameObject.GetComponent<CannonballScript>();

        health -= cannonball.Damage;

        // once a cannonball does damage it shouldn't damage again
        // TODO: cannonball explode animaton
        cannonball.Explode();

        if (health <= 0)
        {
            DestroyBlock(cannonball);
        }
    }

    private void DestroyBlock(CannonballScript cannonBball)
    {
        destroyAudioSource.Play();
        //disable the colliders
        colliders.ForEach(r => r.enabled = false);
        // disable the joints so blocks can go seperate ways
        allJoints.ForEach(r => r.enabled = false);
        sprites.ForEach(r => {
            var velocity = cannonBball.gameObject.GetComponent<Rigidbody2D>().velocity;
            // trying to make the speed random, doesnt really work
            velocity = velocity * Random.Range(1.0f, 5.0f);
            r.velocity = velocity;
        });
        Destroy(gameObject, destroyAudioSource.clip.length); // destroy object after clip finishes
    }
}
