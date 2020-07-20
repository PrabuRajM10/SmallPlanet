
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public GameObject Planet;
    public Joystick joystick;
    //public GameObject PlayerPlaceholder;


    public float speed = 4;
    public float JumpHeight = 1.2f;
    public float movSpeed = 3f;
    public float value = 6f;
    public float acce = 0.2f;
    private float maxSpeed = 15f;

    float gravity = 100;
    bool OnGround = false;


    float distanceToGround;
    Vector3 Groundnormal;



    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        //MOVEMENT
        //if(joystick.Vertical >= .5f)
        //{
        //    //float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //}
        //if (joystick.Vertical <= -.5f)
        //{
        //    //float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //    transform.Translate(-Vector3.forward * speed * Time.deltaTime);


        //}
        if (movSpeed < maxSpeed)
        {
            movSpeed += Time.deltaTime * acce;

        }

        transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);



        ////Local Rotation
        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touch_pos = Camera.main.ScreenToWorldPoint(touch.position);
        if (Input.GetKey(KeyCode.E))
        //if (joystick.Horizontal >= 0.2f)
            {

                transform.Rotate(0, 200 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            //else if (joystick.Horizontal <= -0.2f)

            {

                transform.Rotate(0, -200 * Time.deltaTime, 0);
            }
        else
        {
            transform.Rotate(0, 0, 0);
        }
        //}
       

        //Jump

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(transform.up * 40000 * JumpHeight * Time.deltaTime);

        //}



        //GroundControl

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {

            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if (distanceToGround <= 0.2f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }


        }


        //GRAVITY and ROTATION

        //Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        //if (OnGround == false)
        //{
        //    rb.AddForce(gravDirection * -gravity);

        //}

        ////

        //Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        //transform.rotation = toRotation;

        

    }


    //CHANGE PLANET

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.transform != Planet.transform)
    //    {

    //        Planet = collision.transform.gameObject;

    //        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

    //        Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
    //        transform.rotation = toRotation;

    //        rb.velocity = Vector3.zero;
    //        rb.AddForce(gravDirection * gravity);


    //        PlayerPlaceholder.GetComponent<TutorialPlayerPlaceholder>().NewPlanet(Planet);

    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "World")
        {
            Debug.Log("hit");
        }
    }
}
