using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool isWhiteTurn = true;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void MovePiece(Vector2Int from, Vector2Int to)
    {
        GameObject piece = BoardManager.Instance.GetPieceAtPosition(from);
        if (piece != null)
        {
            Piece pieceScript = piece.GetComponent<Piece>();
            if (pieceScript != null && pieceScript.IsValidMove(from, to))
            {
                BoardManager.Instance.MovePiece(from, to);
                isWhiteTurn = !isWhiteTurn;
            }
            else
            {
                Debug.Log("Invalid move!");
            }
        }
    }

    public bool IsWhiteTurn()
    {
        return isWhiteTurn;
    }
}
