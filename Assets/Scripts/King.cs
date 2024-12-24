using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        // Ensure the destination is within one square in any direction
        int dx = Mathf.Abs(from.x - to.x);
        int dy = Mathf.Abs(from.y - to.y);

        if ((dx <= 1 && dy <= 1) && IsInBounds(to))
        {
            return true;
        }
        return false;
    }
}
