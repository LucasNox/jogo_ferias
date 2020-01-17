using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement : MonoBehaviour
{
    public Vector3 GetNewPosition(Vector3 old_pos, int xDir, int yDir)
    {
        Tilemap tlmap = GetComponent<Tilemap>();
        Vector3Int cell = tlmap.WorldToCell(old_pos);
        cell.x = cell.x + xDir;
        cell.y = cell.y + yDir;
        if(tlmap.GetTile(cell) != null)
        {
            return tlmap.GetCellCenterWorld(cell);
        }
        else
        {
            return new Vector3();
        }
    }
}
