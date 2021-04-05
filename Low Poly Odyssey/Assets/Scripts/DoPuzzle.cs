using UnityEngine;
using UnityEngine.UI;

public class DoPuzzle : MonoBehaviour
{
    public GameObject hudUI;
    public GameObject puzzle;
    public GameManager gameManager;
    public GameObject puzzleManager;
    public Text triggerEnterText;

    GameObject playerPrefab;
    
    Text topText;
    Text bottomText;

    public string topTextSolved;
    public string bottomTextSolved;

    bool solved = false;

    void Start()
    {
        float triggerOffset = 2.0f;
        var parentScale = gameObject.transform.parent.localScale;
        transform.localScale = parentScale + (1.0f + triggerOffset) * parentScale;
        
        topText = puzzle.GetComponentsInChildren<Text>()[0];
        bottomText = puzzle.GetComponentsInChildren<Text>()[1];
    }

    void Update()
    {
        if (!solved && playerPrefab != null && Input.GetButtonDown("Fire1"))
        {
            playerPrefab.GetComponent<CameraController>().DisableMovement();
            playerPrefab.GetComponent<PlayerController>().DisableMovement();
            puzzle.SetActive(true);
            hudUI.SetActive(false);
            //Time.timeScale = 0.0f;
        }

        if (puzzle.GetComponent<Puzzle>().IsSolved())
        {
            solved = true;
            puzzle.GetComponent<Puzzle>().Finish();
            topText.text = topTextSolved;
            bottomText.text = bottomTextSolved;
        }

        if (playerPrefab != null && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPuzzle();
            //Time.timeScale = 1.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!solved)
                triggerEnterText.enabled = true;
            playerPrefab = other.gameObject.transform.parent.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerEnterText.enabled = false;
            playerPrefab = null;
        }
    }

    public void ExitPuzzle()
    {
        if (solved)
        {
            gameManager.totalScore += 150;
            puzzleManager.GetComponent<PuzzleManager>().StopSparks();
            triggerEnterText.enabled = false;
        }

        playerPrefab.GetComponent<CameraController>().EnableMovement();
        playerPrefab.GetComponent<PlayerController>().EnableMovement();

        puzzle.SetActive(false);
        hudUI.SetActive(true);
    }
}
