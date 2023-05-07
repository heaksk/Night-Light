using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Key and AudioSource")]
    public AudioSource audioSource;
    public AudioClip keyclip;

    [Header("FlashLight Object")]
    [SerializeField] private Flashlight Flashlight;


    [Header("Movement")]
    public float walkSpeed = 3.0f;
    private Vector3 movement;
    private float movementSqrMagnitude;
    private Vector3 playerPosition;
    Animator animator;

    private bool movedLeft = false;
    private bool movedRight = false;
    private bool movedUp = false;
    private bool movedDown = false;

    [Header("Key Counter")]
    [SerializeField] public TextMeshProUGUI keyCount;
    public event EventHandler OnKeysChanged;
    private List<Key.KeyType> keyList;
    private int keyCounter;

    //Walking Animation

    void Animation()
    {
        if (movement.x < 0){
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("FacingLeft", false);

            movedLeft = true;
            movedRight = false;
            movedUp = false;
            movedDown = false;
        }
        else if (movement.x > 0){
            animator.SetBool("IsRight", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("FacingRight", false);

            movedLeft = false;
            movedRight = true;
            movedUp = false;
            movedDown = false;
        }
        else if (movement.y < 0){
            animator.SetBool("IsDown", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("FacingDown", false);

            movedLeft = false;
            movedRight = false;
            movedUp = false;
            movedDown = true;
        }
        else if (movement.y > 0){
            animator.SetBool("IsUp", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("FacingUp", false);

            movedLeft = false;
            movedRight = false;
            movedUp = true;
            movedDown = false;
        }
        else{
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);

            if (movedLeft){
                animator.SetBool("FacingLeft", true);
                animator.SetBool("FacingRight", false);
                animator.SetBool("FacingUp", false);
                animator.SetBool("FacingDown", false);
            }
            else if (movedRight){
                animator.SetBool("FacingLeft", false);
                animator.SetBool("FacingRight", true);
                animator.SetBool("FacingUp", false);
                animator.SetBool("FacingDown", false);
            }
            else if (movedUp){
                animator.SetBool("FacingLeft", false);
                animator.SetBool("FacingRight", false);
                animator.SetBool("FacingUp", true);
                animator.SetBool("FacingDown", false);
            }
            else if (movedDown){
                animator.SetBool("FacingLeft", false);
                animator.SetBool("FacingRight", false);
                animator.SetBool("FacingUp", false);
                animator.SetBool("FacingDown", true);
            }
        }
    }

    //Flashlight

    public Vector3 GetMouseWorldPosition() {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        public Vector3 GetMouseWorldPositionWithZ() {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        public Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

    // Key

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        keyCounter += 1;
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
        keyCount.text = keyCounter.ToString();
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        keyCounter -= 1;
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
        keyCount.text = keyCounter.ToString();
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    public int GetKeys(){
        return keyCounter;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        //If player touches a Key
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            audioSource.clip = keyclip;
            audioSource.Play();
            Destroy(key.gameObject);
        }

        //If player touches a Door
        Door door = collider.GetComponent<Door>();
        if (door != null)
        {
            if (ContainsKey(door.GetKeyType()))
            {
                // Currently holding Key to open this door
                door.OpenDoor();
            }
        }
    }

    //Start and Update

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPosition = transform.position;
    }

   void Update()
    {

        Vector3 targetPosition = GetMouseWorldPosition();
        playerPosition = transform.position;
        Vector3 aimDir = (targetPosition - playerPosition).normalized;
        Flashlight.SetAimDirection(aimDir);
        Flashlight.SetOrigin(transform.position);

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movementSqrMagnitude = movement.sqrMagnitude;

        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
        Animation();
    }   

}

