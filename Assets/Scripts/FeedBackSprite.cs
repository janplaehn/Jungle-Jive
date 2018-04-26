using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FeedBackSprite : MonoBehaviour {
    private Vector2 direction = Vector2.zero;
    public float speed = 3f;
    public float lifeTime = 1f;

	// Use this for initialization
	void Start () {
        direction.y = 1f;
        direction.Normalize();
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0);
	}

    public void SetSprite(Sprite givenSprite)
    {
        GetComponent<SpriteRenderer>().sprite = givenSprite;
    }
}
