using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        // Check if the move is along a diagonal
        if (Mathf.Abs(from.x - to.x) == Mathf.Abs(from.y - to.y))
        {
            return IsPathClear(from, to);
        }
        return false;
    }

    private bool IsPathClear(Vector2Int from, Vector2Int to)
    {
        int stepX = (to.x > from.x) ? 1 : -1;
        int stepY = (to.y > from.y) ? 1 : -1;

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
