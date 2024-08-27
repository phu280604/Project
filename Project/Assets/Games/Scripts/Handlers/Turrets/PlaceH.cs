using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlaceH : MonoBehaviour
{
    #region --- Method ---

    #region -- Get mouse tile position
    public Vector3Int GetMouseTilePosition()
    {
        // Lấy vị trí của chuột trong thế giới
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0; // Đảm bảo z là 0 cho không gian 2D

        // Chuyển đổi vị trí thế giới sang vị trí Tile

        return CheckingCondition(tileMap.WorldToCell(mouseWorldPosition));
    }
    #endregion

    #region -- Checking limit map --
    private Vector3Int CheckingCondition(Vector3Int curPos)
    {
        Vector3 dir = curPos - Vector3Int.zero;
        Vector3 dirNormalize = dir.normalized;

        int signY = 1;
        int signX = 1;
        if ((mapD.MapW * -1) <= curPos.x && curPos.x < mapD.MapW)
        {
            if ((mapD.MapH * -1) <= curPos.y && curPos.y < mapD.MapH)
            {
                // TT.
                return curPos;
            }
            else
            {
                int maxH = mapD.MapH;

                if (dir.normalized.y < 0)
                    signY = -1;
                if (signY > 0)
                    maxH -= 1;

                // TF.
                return new Vector3Int(curPos.x, maxH * signY, 0);
            }
        }
        else
        {
            if ((mapD.MapH * -1) <= curPos.y && curPos.y < mapD.MapH)
            {
                int maxW = mapD.MapW;

                if (dir.normalized.x < 0)
                    signX = -1;
                if (signX > 0)
                    maxW -= 1;

                // FT.
                return new Vector3Int(maxW * signX, curPos.y, 0);
            }
            else
            {
                int maxH = mapD.MapH;

                if (dir.normalized.y < 0)
                    signY = -1;
                if (signY > 0)
                    maxH -= 1;

                int maxW = mapD.MapW;
                if (dir.normalized.x < 0)
                    signX = -1;
                if (signX > 0)
                    maxW -= 1;

                // FF
                return new Vector3Int(maxW * signX, maxH * signY, 0);
            }
        }
    }
    #endregion

    #region -- Checking place --
    public void CheckingPlace()
    {
        // Lấy vị trí chuột hiện tại.
        Vector3Int tilePosition = GetMouseTilePosition();

        // Đặt highlight mới
        if (tileMap.HasTile(tilePosition))
        {
            tileMap.SetTileFlags(tilePosition, TileFlags.None);
            tileMap.SetColor(tilePosition, Color.red);
        }

        if ((tilePosition - this.tilePosition).magnitude >= 1)
        {
            // Xóa highlight
            tileMap.SetTileFlags(this.tilePosition, TileFlags.None);
            tileMap.SetColor(this.tilePosition, Color.white);
        }

        this.tilePosition = tilePosition;

        gameObject.transform.position = new Vector3(tilePosition.x + 0.5f, tilePosition.y + 0.5f, -1);
    }
    #endregion

    #region -- Start build --
    public void StartBuilding()
    {

        if (Input.GetMouseButtonDown(0))
        {
            status.IsPlacing = true;

            // Xóa highlight
            tileMap.SetTileFlags(tilePosition, TileFlags.None);
            tileMap.SetColor(tilePosition, Color.white);
        }
    }
    #endregion

    private void Update()
    {
        if (!status.IsPlacing)
        {
            CheckingPlace();
            StartBuilding();
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatusH status;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private MapDatas mapD;
    [SerializeField] private Vector3Int tilePosition;

    #endregion
}
