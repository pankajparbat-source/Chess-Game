using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        // Check for diagonal, horizontal, or vertical movement
        if (Mathf.Abs(from.x - to.x) == Mathf.Abs(from.y - to.y) ||
            from.x == to.x || from.y == to.y)
        {
            return IsPathClear(from, to);
        }
        return false;
    }

    private bool IsPathClear(Vector2Int from, Vector2Int to)
    {
        int stepX = (to.x > from.x) ? 1 : (to.x < from.x ? -1 : 0);
        int stepY = (to.y > from.y) ? 1 : (to.y < from.y ? -1 : 0);

        Vector2Int current = from + new Vector2Int(stepX, stepY);
        while (current != to)
        {
            if (BoardManager.Instance.GetPieceAtPosition(current) != null)
                return false;
            current += new Vector2Int(stepX, stepY);
        }
        return true;
    }
}
