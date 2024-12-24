using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        int dx = Mathf.Abs(from.x - to.x);
        int dy = Mathf.Abs(from.y - to.y);

        // Check for the "L" shaped movement
        if ((dx == 2 && dy == 1) || (dx == 1 && dy == 2))
        {
            return true;
        }
        return false;
    }
}
