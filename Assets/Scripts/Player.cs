using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float NormalSpeed;
    [SerializeField] private float DebuffSpeed;
    [SerializeField] private Sprite DebuffSkin;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator cameraAnim;

    private Sprite _defaultSkin;
    private float _timeToFinishedDebuff;
    private bool _hasDebuff;
    private float _speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraAnim = Camera.main.GetComponent<Animator>();

        _defaultSkin = spriteRenderer.sprite;
        _speed = NormalSpeed;
    }

    void FixedUpdate()
    {
        if (_hasDebuff && Time.time > _timeToFinishedDebuff)
        {
            _speed = NormalSpeed;
            _hasDebuff = false;
            spriteRenderer.sprite = _defaultSkin;

            cameraAnim.SetBool("hasDebuff", false);
        }

       float _direction = Input.GetAxisRaw("Horizontal");
       rb.velocity = (Vector2.right * _direction * _speed);
    }

    public void GetDebuff(float duration)
    {
        _timeToFinishedDebuff = Time.time + duration;

        if (!_hasDebuff)
        {
            _speed = DebuffSpeed;
            _hasDebuff = true;
            spriteRenderer.sprite = DebuffSkin;

            cameraAnim.SetBool("hasDebuff", true);
        }
    }
}
