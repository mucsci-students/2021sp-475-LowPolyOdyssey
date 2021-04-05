using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement/Speed")]
    public float acceleration = 30.0f;
    public float maxSpeed = 50.0f;
    private Rigidbody rb;
    private bool canMove;
    private float normalDrag;
    public GameObject player;

    [Header("Canvas")]
    public GameObject beginText;
    public GameObject warningPrompt;
    public GameObject warningTime;
    public GameObject redWarning;
    public Text warningTimer;
    public GameObject pauseMenu;
    public GameObject youDied;

    [Header("Sounds")]
    public AudioClip AirHiss;
    

    private float curtime = 0.0f;
    private AudioSource m_AudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EnableMovement();
        m_AudioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(!pauseMenu.activeSelf){
            if (Input.GetKeyDown("w") ||
                Input.GetKeyDown("a") ||
                Input.GetKeyDown("s") ||
                Input.GetKeyDown("d") ||
                Input.GetKeyDown("space") ||
                Input.GetKeyDown("left shift"))
            {
                m_AudioSource.clip = AirHiss;
                m_AudioSource.Play();
            }
        }
        
        if(Input.GetKeyDown("q")){
            warningPrompt.SetActive(false);
        }
        
        curtime -= 1 * Time.deltaTime;
        warningTimer.text = curtime.ToString("0");
        
        if(curtime <= 0 && redWarning.activeSelf){
            warningTimer.enabled = false;
            // kill player >:D
            redWarning.SetActive(false);
            youDied.SetActive(true);
            player.GetComponent<CameraController>().DisableMovement();
            player.GetComponent<PlayerController>().DisableMovement();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }

        if(beginText.activeSelf){
            player.GetComponent<CameraController>().DisableMovement();
            player.GetComponent<PlayerController>().DisableMovement();
            if(Input.GetKeyDown("c")){
                beginText.SetActive(false);
                player.GetComponent<CameraController>().EnableMovement();
                player.GetComponent<PlayerController>().EnableMovement();
            }
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 direction = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));
            
            float physicalSpeed = Mathf.Sqrt(rb.velocity.x * rb.velocity.x +
                                            rb.velocity.y * rb.velocity.y +
                                            rb.velocity.z * rb.velocity.z);

            // Keep adding speed, capping it at a maximum threshold
            if (physicalSpeed < maxSpeed)
            {
                rb.AddRelativeForce(100 * acceleration * direction * Time.fixedDeltaTime);
                rb.AddForce(0, 100 * acceleration * Input.GetAxisRaw("Jump") * Time.fixedDeltaTime, 0);
            }
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Earth")){
            StartTimer();
            warningPrompt.SetActive(true);
            redWarning.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.CompareTag("Earth")){
            warningTimer.enabled = false;
            warningTime.SetActive(false);
            redWarning.SetActive(false);
        }
    }

    public void StartTimer(){
        curtime = 20.0f;
        warningTime.SetActive(true);
        warningTimer.enabled = true;
    }

    public void EnableMovement()
    {
        rb.constraints = RigidbodyConstraints.None;
        canMove = true;
    }

    public void DisableMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        canMove = false;
    }
}
