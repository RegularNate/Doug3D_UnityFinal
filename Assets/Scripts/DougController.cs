using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(CharacterController))]
public class DougController : MonoBehaviour {


    //Public variables for the basics of getting Doug around
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 6.0f;
    public float rotateSpeed = 3.0f;
    public float gravity = 9.81f;

    public float score = 0;

    //Used to hold the values to move Doug
    Vector3 moveDirection = Vector3.zero;

    //Character Controller object    
    CharacterController cc;

    //Handles the gun and projectiles
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;
    public float fireSpeed = 20.0f;


    //Gun list
    public List<GameObject> Weapons;
    public List<Transform> DougletSpawns;


    Vector3 putAway = new Vector3(0, 0.5f, -1f);
    Vector3 putAwayRotate = new Vector3(180, 0, 0);



    public GameObject[] HitList;
    Stack HitStack;


    // Use this for initialization
    void Start()
    {
        //Gets the controller, returning a debug message if not found
        cc = GetComponent<CharacterController>();

        if (!cc)
            Debug.Log("CharacterController does not exist.");

        for(int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].transform.Translate(putAway);
            Weapons[i].transform.Rotate(putAwayRotate);
        }

        HitStack = new Stack();

    }

    // Update is called once per frame
    void Update()
    {


        if (HitStack.Count > 0)
        {
            GameObject lastObject = HitStack.Peek() as GameObject;

            Debug.DrawLine(transform.position, lastObject.transform.position, Color.cyan);
        }

        //Checks if Doug is grounded before he jumps or moves around, may take out in final game
            if (cc.isGrounded)
            {            
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);               
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= moveSpeed;
                
                if (Input.GetButtonDown("Jump"))
                    moveDirection.y = jumpSpeed;
            }
        //Puts in a gravity when the Rigibody is turned off
            moveDirection.y -= gravity * Time.deltaTime;
            cc.Move(moveDirection * Time.deltaTime);


        if(Input.GetKeyDown("1"))
        {
            WeaponSwap(1);
        }
        if (Input.GetKeyDown("2"))
        {
            WeaponSwap(2);
        }
        if (Input.GetKeyDown("3"))
        {
            WeaponSwap(3);
        }
        if (Input.GetKeyDown("4"))
        {
            WeaponSwap(4);
        }

  

        //SHooting code
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Doug!");
            if (projectilePrefab)
            {
                Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
                temp.AddForce((projectileSpawnPoint.transform.forward)* fireSpeed, ForceMode.Impulse);
            }
            else
                Debug.Log("Not Doug..");
        }


        
    }

    void WeaponSwap(int _weapon)
    {
                Weapons[_weapon - 1].transform.Translate(putAway);
                Weapons[_weapon - 1].transform.Rotate(putAwayRotate * -1);
    }

    void OnTriggerEnter(Collider _c)
    {
        Debug.Log(_c.gameObject.name);
        Debug.Log(_c.gameObject.tag);

        
        if (!HitStack.Contains(_c.gameObject))
        {
            HitStack.Push(_c.gameObject);

            HitList = new GameObject[HitStack.Count];

            HitStack.CopyTo(HitList, 0);
        }

        if (_c.gameObject.tag == "PowerUp")
        {
            Destroy(_c.gameObject);
            score += 50;
            Debug.Log("Your score is: " + score);
        }
    }


    IEnumerator popTheStack()
    {
        yield return new WaitForSeconds(2);

        if (HitStack.Count > 0)
        {
            HitStack.Pop();

            HitList = new GameObject[HitStack.Count];

            HitStack.CopyTo(HitList, 0);

            StopCoroutine("popTheStack");
        }
    }

}
