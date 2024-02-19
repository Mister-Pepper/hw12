//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor.SceneManagement;

//public class Player : MonoBehaviour
//{

//    public GameObject nExit;
//    public GameObject sExit;
//    public GameObject eExit;
//    public GameObject wExit;

//    private bool amMoving = false;

//    public float speed = .01f;

//    private bool amAtMiddleOfRoom = false;

//    private void turnOffExits()
//    {
//        this.nExit.gameObject.SetActive(false);
//        this.sExit.gameObject.SetActive(false);
//        this.eExit.gameObject.SetActive(false);
//        this.wExit.gameObject.SetActive(false);

//    }

//    private void turnOnExits()
//    {
//        this.nExit.gameObject.SetActive(true);
//        this.sExit.gameObject.SetActive(true);
//        this.eExit.gameObject.SetActive(true);
//        this.wExit.gameObject.SetActive(true);
//    }


//    // Start is called before the first frame update
//    void Start()
//    {
//        // if this is not our first scene, hence we compare current direction to a question mark
//        if(!Singleton.currentDirection.Equals("?"))
//        {
//            if (Singleton.currentDirection.Equals("north"))
//            {
//                this.gameObject.transform.position = this.sExit.transform.position;
//            }
//        }
//    }

//    private void onTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("door"))
//        {
//            Singleton.currentDirection = "north";
//            EditorSceneManager.LoadScene("Second");
//        }
//        else if (other.CompareTag("middleOfTheRoom") && !Singleton.currentDirection.Equals("?"))
//        {
//            print("at middle of Room");
//            this.amAtMiddleOfRoom = true;
//        }

//    }
//    // Update is called once per frame
//    void update()
//    {

//        this.turnOffExits();

//        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
//        {
//            this.turnOnExits();
//            this.amMoving = true;
//            Singleton.currentDirection = "north";
//            this.gameObject.transform.LookAt(this.sExit.transform.position);
//        }
//        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
//        {
//            this.turnOnExits();
//            this.amMoving = true;
//            Singleton.currentDirection = "south";
//            this.gameObject.transform.LookAt(this.nExit.transform.position);
//        }
//        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
//        {
//            this.turnOnExits();
//            this.amMoving = true;
//            Singleton.currentDirection = "east";
//            this.gameObject.transform.LookAt(this.wExit.transform.position);
//        }
//        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
//        {
//            this.turnOnExits();
//            this.amMoving = true;
//            Singleton.currentDirection = "west";
//            this.gameObject.transform.LookAt(this.eExit.transform.position);
//        }


//        if (Singleton.currentDirection.Equals("north"))
//        {
//            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.nExit.transform.position, this.speed * Time.deltaTime);
//        }
//        if (Singleton.currentDirection.Equals("south"))
//        {
//            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.sExit.transform.position, this.speed*Time.deltaTime);
//        }
//        if (Singleton.currentDirection.Equals("east"))
//        {
//            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eExit.transform.position, this.speed * Time.deltaTime);
//        }
//        if (Singleton.currentDirection.Equals("west"))
//        {
//            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.wExit.transform.position, this.speed * Time.deltaTime);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    // this is a rigidbody variable that will be used to stop the moving ball once it is triggers as middle of the room is true.
    private Rigidbody rb;

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        print(amAtMiddleOfRoom);

        // set rb to the current objects rigidbody
        rb = GetComponent<Rigidbody>();

        //disable all exits when the scene first loads
        this.turnOffExits();

        //not our first scene
        if (!Singleton.currentDirection.Equals("?"))
        {
            if (Singleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
            else if (Singleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
            }
            else if (Singleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
            }
            else if (Singleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
            }
        }
        // testing 
        print(amAtMiddleOfRoom);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Second");
        }
        if (other.CompareTag("MiddleOfTheRoom") && !Singleton.currentDirection.Equals("?"))
        {
            this.amAtMiddleOfRoom = true;
            // testing
            print(amAtMiddleOfRoom);


            if (this.amAtMiddleOfRoom = true)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
       
      

        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            Singleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            Singleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            Singleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            Singleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

        }

        //make the player move in the current direction
        if (Singleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (Singleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (Singleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (Singleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }
    }
}