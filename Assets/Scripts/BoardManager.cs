using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance; // Singleton for easy access

    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    private GameObject[,] _chessBoard=null;
    public GameObject[,] ChessBoard = new GameObject[8, 8];

    public GameObject whitePawnPrefab, blackPawnPrefab;
    public GameObject whiteRookPrefab, blackRookPrefab;
    public GameObject whiteKnightPrefab, blackKnightPrefab;
    public GameObject whiteBishopPrefab, blackBishopPrefab;
    public GameObject whiteQueenPrefab, blackQueenPrefab;
    public GameObject whiteKingPrefab, blackKingPrefab;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        GenerateArray();
        SetupBoard();
    }

    private void SetupBoard()
    {
        // Place white pawns
        for (int i = 0; i < 8; i++)
            CreatePiece(whitePawnPrefab, i, 1);

        // Place black pawns
        for (int i = 0; i < 8; i++)
            CreatePiece(blackPawnPrefab, i, 6);

        // Place rooks
        CreatePiece(whiteRookPrefab, 0, 0);
        CreatePiece(whiteRookPrefab, 7, 0);
        CreatePiece(blackRookPrefab, 0, 7);
        CreatePiece(blackRookPrefab, 7, 7);


        CreatePiece(whiteKnightPrefab, 1, 0);
        CreatePiece(whiteKnightPrefab, 6, 0);
        CreatePiece(blackKnightPrefab, 1, 7);
        CreatePiece(blackKnightPrefab, 6, 7);

        CreatePiece(whiteBishopPrefab, 2, 0);
        CreatePiece(whiteBishopPrefab, 5, 0);
        CreatePiece(blackBishopPrefab, 2, 7);
        CreatePiece(blackBishopPrefab, 5, 7);


        // Add other pieces similarly...

        // Place Kings
        CreatePiece(whiteKingPrefab, 4, 0);
        CreatePiece(blackKingPrefab, 3, 7);
        CreatePiece(whiteQueenPrefab, 3, 0);
        CreatePiece(blackQueenPrefab, 4, 7);
    }

    private void CreatePiece(GameObject prefab, int x, int y)
    {
        GameObject piece = Instantiate(prefab, _chessBoard[x,y].transform.position, Quaternion.identity);
        ChessBoard[x, y] = piece;
    }

    public GameObject GetPieceAtPosition(Vector2Int position)
    {
        return ChessBoard[position.x, position.y];
    }

    public void MovePiece(Vector2Int from, Vector2Int to)
    {
        GameObject piece = ChessBoard[from.x, from.y];
        ChessBoard[from.x, from.y] = null;
        ChessBoard[to.x, to.y] = piece;

        piece.transform.position = new Vector3(to.x, 0, to.y);
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
                // Ensure the tile has a collider (like a BoxCollider)
                if (_chessBoard[i, j].GetComponent<Collider>() == null)
                {
                    _chessBoard[i, j].AddComponent<BoxCollider>();
                }
            }
        }

    }
}
