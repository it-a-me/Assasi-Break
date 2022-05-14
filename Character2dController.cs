using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//linear drag = 1 cameera = followplayer 
public class Character2dController : MonoBehaviour
{
    public float health;
    [SerializeField] private float MovementSpeed = 8;
    [SerializeField] private GameObject defeatedPlayerPrefab;

    [SerializeField] private int maxDegrees = 18;
    [SerializeField] private float rotationSpeed = 23f;
    [SerializeField] private float jetForce = 20f;
    [SerializeField] private float angleNormalizationSpeed = 0.98f;
    [SerializeField] private float jetBoostPower = 30;
    [SerializeField] private float jetBoostCooldown = 2;
    [SerializeField] private bool devMode = false;
    private float activeCooldown = 0;
    private Rigidbody2D _rigidbody;

    private sbyte direction;
    private bool onGround = false;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
    }
    private void FixedUpdate()
    {

        Vector3 newScale = transform.localScale;
        //do jetpack
        if (Input.GetKey("space"))
        {
            //add force.  Horizonal based off angle and vertical based of distanct from vertical
            _rigidbody.AddForce(new Vector2(jetForce * Time.deltaTime * -_rigidbody.rotation / 90, jetForce * Time.deltaTime * (1 - Mathf.Abs(_rigidbody.rotation / 90))), ForceMode2D.Impulse);
        }
        RaycastHit2D groundDetect = Physics2D.Linecast(transform.position + new Vector3(-1, -1.2f, 0), transform.position + new Vector3(1, -1.2f, 0));
        
        if (groundDetect.collider == null)
        {
            onGround = false;
            if (Input.GetAxis("Horizontal") != 0)
            {
                //rotates based off horizontal movement axis
                _rigidbody.SetRotation(Mathf.Max(Mathf.Min(_rigidbody.rotation + rotationSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime, maxDegrees), -maxDegrees));
            }
            else
            {
                //rotates back to vertical when no horiontal button is pressed.
                if (_rigidbody.rotation > 0)
                {
                    _rigidbody.SetRotation(Mathf.Floor(_rigidbody.rotation * angleNormalizationSpeed * 10) / 10);
                }
                else if (_rigidbody.rotation < 0)
                {
                    _rigidbody.SetRotation(Mathf.Ceil(_rigidbody.rotation * angleNormalizationSpeed * 10) / 10);
                }
            }
     
        }

        else
        {
            onGround = true;
            //fixed rotation when on the ground
            _rigidbody.SetRotation(0);
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * MovementSpeed;
        }


        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            newScale.x = Mathf.Abs(newScale.x);
        }
        else 
        {
            newScale.x = -Mathf.Abs(newScale.x);
        }
        transform.localScale = newScale;
    }

    private void Update()
    {
        direction = (sbyte)Mathf.Sign(transform.lossyScale.x);
        activeCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonUp(1) && activeCooldown < 0){
            JetBoost();
        }
    } 
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0 && !devMode)
        {
            Instantiate(defeatedPlayerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void JetBoost()
    {
        activeCooldown = jetBoostCooldown;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float dx = mousePos.x - transform.position.x;
        float dy = mousePos.y - transform.position.y;
        float dist = Mathf.Sqrt(Mathf.Pow(dx, 2)+Mathf.Pow(dy,2));

        Vector2 f = new Vector2(dx/dist, dy/dist) * jetBoostPower;
        _rigidbody.AddForce(f, ForceMode2D.Impulse);

    }
}

