using UnityEngine;

public enum Angle
{
    North = 0,
    East = 90,
    South = 180,
    West = 270
}

public enum Shape
{
    Straight,
    Cross,
    T,
    Curved
}

public class Pipe : MonoBehaviour
{
    public bool solutionPipe = false;
    public Angle solutionAngle;
    public Shape type;

    [HideInInspector] public bool finished = false;

    public void Rotate()
    {
        if (!finished)
            GetComponent<RectTransform>().Rotate(0, 0, 90);
    }

    public bool IsSolved()
    {
        if (!solutionPipe || type == Shape.Cross)
            return true;

        float currAngle = GetComponent<RectTransform>().eulerAngles.z;
        if (type == Shape.Straight)
            currAngle %= 180;
        return (float) solutionAngle == currAngle;
    }
}
