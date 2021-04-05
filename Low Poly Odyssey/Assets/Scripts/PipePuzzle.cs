using UnityEngine;
using UnityEngine.UI;
using System;

public class PipePuzzle : MonoBehaviour, Puzzle
{
    public Sprite[] filledSprites;
    public Color solvedColor;
    public Image[] tanks;

    void Start()
    {
        solvedColor = new Color(solvedColor.r, solvedColor.g, solvedColor.b, 255);
        foreach (Image t in tanks)
            t.color = solvedColor;
    }

    public bool IsSolved()
    {
        foreach (Pipe p in GetComponentsInChildren<Pipe>())
            if (!p.IsSolved())
                return false;

        foreach (Pipe p in GetComponentsInChildren<Pipe>())
            p.finished = true;

        return true;
    }

    public void Finish()
    {
        foreach (Pipe p in GetComponentsInChildren<Pipe>())
        {
            if (p.solutionPipe && p.IsSolved())
            {
                string emptyName = p.gameObject.GetComponent<Image>().sprite.name;
                var idx = Convert.ToInt32(emptyName[emptyName.Length - 1]) - 48;
                p.gameObject.GetComponent<Image>().color = solvedColor;
                p.gameObject.GetComponent<Image>().sprite = filledSprites[idx];
            }
        }
    }
}
