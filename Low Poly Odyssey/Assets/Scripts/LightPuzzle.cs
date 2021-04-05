using UnityEngine;
using UnityEngine.UI;

public class LightPuzzle : MonoBehaviour, Puzzle
{
    public bool IsSolved()
    {
        foreach (PLight light in GetComponentsInChildren<PLight>())
        {
            if (!light.IsLit())
                return false;
        }

        return true;
    }
    
    public void Finish()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.gameObject.SetActive(false);
        }
    }
}
