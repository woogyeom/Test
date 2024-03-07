using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    GameManager gameManager;
    Dungeon dungeon;
    List<Room> rooms;
    List<Corridor> corridors;

    public int numRooms = 10;

    private void Start()
    {
        gameManager = GameManager.Instance;
        dungeon = new Dungeon();
        rooms = dungeon.GetRooms();
        corridors = dungeon.GetCorridors();
    }

    public void GenerateDungeon()
    {
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
