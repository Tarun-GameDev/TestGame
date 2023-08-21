using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;
    public float speed = 10f; //player speed 
    public float jump = 10f; //jump speed

    float _vertical;
    float _horizontal;

    [SerializeField] GameObject deadMenu; //Dead UI
    [SerializeField] GameObject gameFinishedMenu; //GameFinish UI
    [SerializeField] bool gameOver = false;
    Rigidbody rb;
    bool isGrounded = true;
    [SerializeField]
    float raycastDistance;  //Jump Raycast Distance
    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameOver)
            return;

        //Input
         _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(transform.position.y <= -.5f)
        {
            GameOver();
        }

        isGrounded = CheckGround();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);

    }

    private void FixedUpdate()
    {
        if (gameOver)
            return;

        //movement
        transform.position += new Vector3(_horizontal * speed * Time.fixedDeltaTime, 0f, _vertical * speed * Time.fixedDeltaTime);
    }

    //Ground Checking
    private bool CheckGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance, groundLayer))
        {
            return true;
        }
        return false;
    }

    public void GameOver()
    {
        gameOver = true;
        if(deadMenu != null)
            deadMenu.SetActive(true);
        Destroy(gameObject);
    }

    public void GameFinish()
    {
        gameOver = true;
        if (gameFinishedMenu != null)
            gameFinishedMenu.SetActive(true);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            GameOver();
        }
        
        if(collision.collider.CompareTag("Goal"))
        {
            GameFinish();
        }
    }

}
