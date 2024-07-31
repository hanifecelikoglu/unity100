using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;
    private int sayi;
    private bool jump;
    float jumpForce = 2.0f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //caching spriterenderer
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        _animator = GetComponent<Animator>(); //caching anim
        charPos = transform.position;
        sayi = 1;
    }

    private void FixedUpdate()
    {
        if ( jump )
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
        sayi = 2;
    }

    void Update()
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos;

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        //Karakterin Bakis Yonu ile Ilgili Kisim
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") > -0.01f)
        {
            _spriteRenderer.flipY = true;
        }

        sayi = 3;
    }

    private void LateUpdate()
    {
        sayi = 4;
    }
}
