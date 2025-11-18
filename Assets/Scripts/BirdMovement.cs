using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float jumpSpeed = 5f; //vt khi nhay 
    public float gravity = 9.8f; //trong luc
    private float verticalVelocity = 0f; // van toc doc
    
    public int score = 0; //diem so
    protected bool isAlive;
    
    //Animation bird
    private SpriteRenderer spriteRenderer; //Gan components sprites vao game object
    public Sprite[] sprites; //luu tru cac khung hinh frames
    public int spritesIndex; //chi so index cua cac frames

    public Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Lay ra component ben unity
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
    }

    void Start()
    {
        isAlive = true;
        InvokeRepeating(nameof(AnimateSprite), 0.15f ,0.15f);
        //tao hieu ung animations, moi 0.15s  goi la ham AnimateSprite
        //(ten,tgianbandau,tgloop)
        rb = GetComponent<Rigidbody2D>();
    }

    private void AnimateSprite()
    {
        spritesIndex++;
        if (spritesIndex >= sprites.Length)
        {
            spritesIndex = 0;
        }
        spriteRenderer.sprite = sprites[spritesIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpSpeed;
        }

        // Mo phong trong luc (giong nem xien theo truc Y) - Vy
        verticalVelocity -= gravity * Time.deltaTime;

        //Cap nhap vi tri theo truc y
        transform.position += new Vector3();
        transform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);

        // xoay con chim theo huong van toc xien
        float rotationZ = Mathf.Atan2(verticalVelocity, 5f) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver(); // tim trong toan bo scene, object nao co GameManager -> tra ve 
        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().Increscore();
        }
    }



}
