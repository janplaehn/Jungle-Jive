using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    public enum Type {Mushroom, Banana, Mirror, Smoke}
    public Type ItemType = Type.Mushroom;
    [Space(7)]

    [Header("Item Sprites")]
    public Sprite mushroom;
    public Sprite banana;
    public Sprite mirror;
    public Sprite smoke;

    [Space(7)]
    public int throwForce;
    public bool isJanTesting = false;
    public bool isRandomised;

    private Rigidbody2D rb;
    private bool isThrown;
    private MirrorEffect mirrorScript;
    
    void Start() {
        isThrown = false;
        rb = GetComponent<Rigidbody2D>();
        mirrorScript = GameObject.Find("GameController").GetComponent<MirrorEffect>();
        if (isRandomised) {
            ItemType = (Type)Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);
        }
        SetSprite();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space) && isJanTesting) {
            AddThrowForce();
        }    
    }


    private void SetSprite() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        switch (ItemType) {
            case Type.Mushroom:
                renderer.sprite = mushroom;
                break;
            case Type.Banana:
                renderer.sprite = banana;
                break;
            case Type.Mirror:
                renderer.sprite = mirror;
                break;
            case Type.Smoke:
                renderer.sprite = smoke;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.transform.parent) {
            if (collision.gameObject.transform.parent.tag == ("Player1") || collision.gameObject.transform.parent.tag == ("Player2")) {
                isThrown = false;
                ActivateItem(collision.gameObject.transform.parent.tag);
                Destroy(this.gameObject);
            }
        }       
    }


    private void AttachToHand(Getbodyparts body) {
        if (body.hasItem && body.Item) {
            if (body.Item != this.gameObject) Destroy(body.Item);
        }
        body.Item = this.gameObject;
        body.hasItem = true;
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        transform.position = body.ThrowingHand.transform.position;
        transform.rotation = body.ThrowingHand.transform.rotation;
        transform.Rotate(Vector3.forward * 180);
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
                Mushroom.Affect(playerTag);
                break;
            case Type.Banana:
                Banana.BananaHit(playerTag);
                GameObject.Find("MiniGame").GetComponent<ItemMiniGame>().ResetPositions(playerTag);
                break;
            case Type.Mirror:
                mirrorScript.ActivateMirror(playerTag);
                break;
            case Type.Smoke:
                Smoke.SmokeInpact(this.transform.position.x);
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }
}
