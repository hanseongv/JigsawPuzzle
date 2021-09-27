using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiiecePosInit : MonoBehaviour
{
    public List<Sprite> sprites;
    public int xCount = 4;
    public int yCount = 3;

    private void Awake()
    {
        InitPosition();
    }

    [ContextMenu("퍼즐 배치")]
    private void InitPosition()
    {
        DeleteOldPiece();
        float pieceWidth = sprites[0].textureRect.width;
        float pieceHeight = sprites[0].textureRect.height;
        int imageIndex = 0;
        for (int y = 1; y <= yCount; y++)
        {
            for (int x = 1; x <= xCount; x++)
            {
                var item = new GameObject($"{x} : {y}", typeof(FixedPiece));
                item.transform.parent = transform;
                RectTransform rt = item.AddComponent<RectTransform>();
                //크기
                rt.sizeDelta = new Vector2(pieceWidth, pieceHeight);
                //위치
                //float xPos = pieceWidth * x; /* (xCount - 1) * 0.5f;*/
                //float yPos = -pieceHeight * y;/*(yCount - 1) * 0.5f;*/

                float xPos = (x - xCount) * (pieceWidth * 0.5f) + (x - 1) * (pieceWidth * 0.5f);
                float yPos = -(y - yCount) * (pieceHeight * 0.5f) + -(y - 1) * (pieceHeight * 0.5f);

                //float xPos = -pieceWidth * (xCount - x) * 0.5f; // x가 1개면 0 2개면 -160
                //float yPos = pieceHeight * (yCount - y) * 0.5f;
                item.transform.localPosition = new Vector3(xPos, yPos, 0);
                item.AddComponent<Image>().sprite = sprites[imageIndex];
                imageIndex++;
            }
        }
    }

    private void DeleteOldPiece()
    {
        var childs = transform.GetComponentsInChildren<Image>();
        foreach (var item in childs)
        {
            //    if (Application.isPlaying)
            //        Destroy(item.gameObject);
            //    else
            DestroyImmediate(item.gameObject);
        }
    }
}