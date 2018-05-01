using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    public enum Type {Mushroom, Banana, Mirror, Smoke}
    public Type ItemType = Type.Mushroom;

    public Sprite mushroomSprite;
    public Sprite bananaSprite;
    public Sprite mirrorSprite;
    public Sprite smokeSprite;

    public int throwForce;

    private Rigidbody2D rb;
    private bool isThrown;
    
    void Start() {
        isThrown = false;
        rb = GetComponent<Rigidbody2D>();
        SetSprite();
    }


    private void SetSprite() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        switch (ItemType) {
            case Type.Mushroom:
                renderer.sprite = mushroomSprite;
                break;
            case Type.Banana:
                renderer.sprite = bananaSprite;
                break;
            case Type.Mirror:
                renderer.sprite = mirrorSprite;
                break;
            case Type.Smoke:
                renderer.sprite = smokeSprite;
                break;
            default:
                break;
        }
    }


    void Update() {
        if (transform.parent) {
            //TODO: Replace this with actual button / wiimote input (probably call AddThrowForce from InputCheck script instead)
            if (Input.GetKey(KeyCode.Space) && (transform.parent.tag == ("hand"))) {
                AddThrowForce();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.transform.parent) {
            if (collision.gameObject.transform.parent.tag == ("Player1") || collision.gameObject.transform.parent.tag == ("Player2")) {
                if (isThrown) {
                    ActivateItem(collision.gameObject.transform.parent.tag);
                }
                else {
                    AttachToHand(collision.gameObject.transform.parent.GetComponent<Getbodyparts>());
                }
            }
        }       
    }


    private void AttachToHand(Getbodyparts body) {
        if (body.hasItem && body.Item) {
            Destroy(body.Item);
        }
        body.Item = this.gameObject;
        body.hasItem = true;
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        transform.position = body.ThrowingHand.transform.position;
        transform.rotation = body.ThrowingHand.transform.rotation;
        transform.parent = body.ThrowingHand.transform;
    }

    public void AddThrowForce() {
        isThrown = true;
        gameObject.transform.parent = null;
        rb.gravityScale = 0.5f;
        if (transform.position.x > 0) {
            rb.AddForce(Vector3.left * throwForce);
        }
        else {
            rb.AddForce(Vector3.right * throwForce);
        }
    }

    private void ActivateItem(string playerTag) {
        Debug.Log("Item Activated");
        switch (ItemType) {
            case Type.Mushroom:
                //Activate script here (Add playerTag as argument)
                break;
            case Type.Banana:
                //Activate script here (Add playerTag as argument)
                break;
            case Type.Mirror:
                //Activate script here (Add playerTag as argument)
                break;
            case Type.Smoke:
                //Activate script here (Add playerTag as argument)
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }
}
