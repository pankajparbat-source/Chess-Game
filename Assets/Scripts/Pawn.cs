using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Pawn : Piece
{
    public override bool IsValidMove(Vector2Int from, Vector2Int to)
    {
        int direction = isWhite ? 1 : -1;

        // Standard forward move
        if (from.x == to.x && to.y == from.y + direction &&
            BoardManager.Instance.GetPieceAtPosition(to) == null)
        {
            return true;
        }

        // Capture move (diagonal)
        if (Mathf.Abs(to.x - from.x) == 1 && to.y == from.y + direction &&
            BoardManager.Instance.GetPieceAtPosition(to) != null)
        {
            return true;
        }

        return false;
    }
}
