using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        if (from.x == to.x || from.y == to.y)  // Horizontal or vertical move
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
