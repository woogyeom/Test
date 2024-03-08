using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    GameManager gameManager;
    BSP bsp;

    Dungeon dungeon;
    List<Room> rooms;
    List<Corridor> corridors;

    public int numRooms = 10;
    public int dungeonX = 0;
    public int dungeonY = 0;
    private Vector2Int topLeft;
    public int dungeonWidth = 100;
    public int dungeonHeight = 100;

    private void Start()
    {
        
    }

    private void ClearDungeon()
    {
        List<Area> combinedArea = new List<Area>();
        combinedArea.AddRange(rooms);
        combinedArea.AddRange(corridors);

        foreach (Area area in combinedArea)
        {
            Dictionary<Vector2Int, Tile> tileDict = area.GetTileDict();
            foreach (Tile tile in tileDict.Values)
            {
                tile.Destroy();
            }
        }

        rooms.Clear();
        corridors.Clear();
        dungeon = null;
    }

    public void GenerateDungeon()
    {
        topLeft = new Vector2Int(dungeonX, dungeonY);
        dungeon = new Dungeon(topLeft, dungeonWidth, dungeonHeight);
        bsp = new BSP(dungeon);
        gameManager = GameManager.Instance;
        rooms = dungeon.GetRooms();
        corridors = dungeon.GetCorridors();

        // 던전 생성
        GenerateRooms();
        GenerateCorridor();
    }

    private void GenerateRooms()
    {
        // 방들 생성
        for (int i = 0; i < numRooms; i++)
        {
            GenerateRoom();
        }

        DrawRoom();
    }

    private void GenerateRoom()
    {
        // 각 방 생성

        GenerateRoomContents();
    }

    private void GenerateRoomContents()
    {
        // 방 내부 생성

    }

    private void DrawRoom()
    {
        // 방 그리기

    }

    private void GenerateCorridor()
    {
        // 통로 생성
        ConnectRooms();
        DrawCorridor();
    }

    private void ConnectRooms()
    {
        // 방들 연결
    }

    private void DrawCorridor()
    {
        // 통로 그리기
    }

}
