using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private Vector2Int selectedPosition = new Vector2Int(-1, -1);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2Int clickedPosition = GetClickedBoardPosition();

            if (selectedPosition == new Vector2Int(-1, -1))
            {
                // Select a piece
                GameObject selectedPiece = BoardManager.Instance.GetPieceAtPosition(clickedPosition);
                if (selectedPiece != null &&
                    selectedPiece.GetComponent<Piece>().isWhite == GameManager.Instance.IsWhiteTurn())
                {
                    selectedPosition = clickedPosition;
                }
            }
            else
            {
                // Try to move the selected piece
                GameManager.Instance.MovePiece(selectedPosition, clickedPosition);
                selectedPosition = new Vector2Int(-1, -1);  // Reset selection
            }
        }
    }

    private Vector2Int GetClickedBoardPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            return new Vector2Int(Mathf.RoundToInt(point.x), Mathf.RoundToInt(point.z));
        }
        return new Vector2Int(-1, -1);  // Invalid click
    }
}
