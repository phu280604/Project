using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlaceH : MonoBehaviour
{
    #region --- Method ---

    #region -- Get touch tile position
    public Vector3Int GetTouchPosition(Touch touch)
    {
        // Lấy vị trí của chuột trong thế giới
        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchWorldPosition.z = 0; // Đảm bảo z là 0 cho không gian 2D

        // Chuyển đổi vị trí thế giới sang vị trí Tile

        return CheckingCondition(tileMap.WorldToCell(touchWorldPosition));
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

    #region -- Highlight first place touch --
    public void FirstHighLightPlaceTouch(Vector3Int tilePos, GameObject prefab)
    {
        // Đặt highlight mới
        if (tileMap.HasTile(tilePos))
        {
            tileMap.SetTileFlags(tilePos, TileFlags.None);
            tileMap.SetColor(tilePos, Color.blue);
        }

        tilePosition = tilePos;

        prefab.transform.position = new Vector3(tilePos.x + 0.5f, tilePos.y + 0.5f, -1);
    }
    #endregion

    #region -- Highlight place touch --
    public void HighLightTileMap(Vector3Int tilePos)
    {
        // Đặt highlight mới
        if (tileMap.HasTile(tilePos))
        {
            tileMap.SetTileFlags(tilePos, TileFlags.None);
            tileMap.SetColor(tilePos, Color.blue);
        }

        RemoveHighLight(tilePos);

        tilePosition = tilePos;
    }
    #endregion

    #region -- Remove highlight
    public void RemoveHighLight(Vector3Int tilePos)
    {
        if ((tilePosition - tilePos).magnitude >= 1)
        {
            // Xóa highlight
            tileMap.SetTileFlags(tilePosition, TileFlags.None);
            tileMap.SetColor(tilePosition, Color.white);
        }
    }
    #endregion

    #region -- Start build --
    public void StartBuilding()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:

                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    // Moving object.
                    RaycastHit2D hitMove = Physics2D.Raycast(touchPosition, Vector2.up, 0.1f, layerMove);
                    if (hitMove.collider != null)
                    {
                        HighLightTileMap(tilePosition);
                        objOption.SetActive(true);

                        isDragging = true;
                    }


                    // Removing object
                    RaycastHit2D hitRemove = Physics2D.Raycast(touchPosition, Vector2.zero, 0.1f, layerRemove);
                    if (hitRemove.collider != null)
                    {
                        tileMap.SetTileFlags(tilePosition, TileFlags.None);
                        tileMap.SetColor(tilePosition, Color.white);

                        if (status.IsPlacing)
                        {
                            StatsTurrets stats = gameObject.GetComponent<StatsTurrets>();

                            switch (gameObject.layer)
                            {
                                case int n when n == LayerMask.GetMask("MKI"):
                                    stats.StatsMKI();
                                    break;

                                case int n when n == LayerMask.GetMask("MKII"):
                                    stats.StatsMKII();
                                    break;

                                case int n when n == LayerMask.GetMask("Tank"):
                                    stats.StatsTank();
                                    break;
                            }
                            healthBar.UpdateHelthBar(0f, stats.MaxHP);
                            gameCommands.Cost += stats.Cost;
                            Destroy(gameObject);
                        }
                        else
                        {
                            Destroy(gameObject);
                        }

                        
                    }

                    // Placing object
                    RaycastHit2D hitPlace = Physics2D.Raycast(touchPosition, Vector2.zero, 0.1f, layerPlace);
                    if (hitPlace.collider != null)
                    {
                        if ((Vector2)gameObject.transform.position != (Vector2)mapD.StartPoint && (Vector2)mapD.EndPoint != (Vector2)gameObject.transform.position)
                        {
                            if (!status.IsPlacing)
                            {
                                StatsTurrets stats = gameObject.GetComponent<StatsTurrets>();
                                gameCommands.Cost -= stats.Cost;
                                healthBar.UpdateHelthBar(stats.Hp, stats.MaxHP);
                            }

                            tileMap.SetTileFlags(tilePosition, TileFlags.None);
                            tileMap.SetColor(tilePosition, Color.white);

                            status.IsPlacing = true;

                            objOption.SetActive(false);
                        }
                        else
                        {
                            tileMap.SetTileFlags(tilePosition, TileFlags.None);
                            tileMap.SetColor(tilePosition, Color.red);
                        }
                    }

                    break;

                #region - Draging -
                case TouchPhase.Moved:
                    Vector3Int touchMove = CheckingCondition(GetTouchPosition(touch));

                    if (isDragging)
                    {
                        gameObject.transform.position = new Vector3(touchMove.x + 0.5f, touchMove.y + 0.5f, -1);
                        Vector3Int highlightTile = new Vector3Int(touchMove.x, touchMove.y);
                        HighLightTileMap(highlightTile);
                    }

                    break;
                #endregion

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }

        if (status.IsPlacing)
        {
            // Xóa highlight
            tileMap.SetTileFlags(tilePosition, TileFlags.None);
            tileMap.SetColor(tilePosition, Color.white);
        }
    }
    #endregion

    private void Update()
    {
        if (gameCommands.BuildingTime)
        {
            StartBuilding();
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;

    [SerializeField] private THealthBarCtrl healthBar;
    [SerializeField] private TurretsCommands commands;
    [SerializeField] private StatusH status;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private MapDatas mapD;

    [SerializeField] private GameObject objOption;

    [SerializeField] static private Vector3Int tilePosition;

    [SerializeField] private LayerMask layerMove;
    [SerializeField] private LayerMask layerPlace;
    [SerializeField] private LayerMask layerRemove;

    [SerializeField] private bool isDragging;

    #endregion
}
