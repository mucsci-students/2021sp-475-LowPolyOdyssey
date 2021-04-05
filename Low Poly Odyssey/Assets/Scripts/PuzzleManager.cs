using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzles;
    public GameObject[] sparks;
    public GameObject puzzleNotif;

    int currentOrderIdx;
    int[] puzzleOrder;

    void Start()
    {
        puzzleOrder = new int[puzzles.Length];
        for (int i = 0; i < puzzleOrder.Length; ++i)
            puzzleOrder[i] = i;

        // Shuffle puzzle ordering
        for (int i = 0; i < 4; ++i)
        {
            int j = Random.Range(0, puzzles.Length);
            // Swap
            int temp = puzzleOrder[i];
            puzzleOrder[i] = puzzleOrder[j];
            puzzleOrder[j] = temp;
        }

        currentOrderIdx = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            puzzleNotif.SetActive(false);
    }

    public void ActivatePuzzle()
    {
        if (currentOrderIdx < puzzles.Length)
        {
            print("Puzzle " + (puzzleOrder[currentOrderIdx] + 1) + " Activated!");
            puzzleNotif.SetActive(true);
            puzzles[puzzleOrder[currentOrderIdx]].SetActive(true);
            sparks[puzzleOrder[currentOrderIdx]].SetActive(true);
            ++currentOrderIdx;
        }
    }

    public void StopSparks()
    {
        sparks[puzzleOrder[currentOrderIdx - 1]].SetActive(false);
    }
}
