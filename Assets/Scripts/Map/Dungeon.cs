using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    private List<Room> rooms;
    private List<Corridor> corridors;

    private Vector2Int topLeft;
    private int x;
    private int y;
    private int width;
    private int height;

    public Dungeon(Vector2Int topLeft, int width, int height)
    {
        this.topLeft = topLeft;
        this.width = width;
        this.height = height;
        rooms = new List<Room>();
    }

    public Vector2Int GetTopLeft()
    {
        return topLeft;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }

    public void RemoveRoom(Room room)
    {
        rooms.Remove(room);
    }

    public List<Room> GetRooms()
    {
        return rooms;
    }

    public void AddCorridor(Corridor corridor)
    {
        corridors.Add(corridor);
    }

    public void RemoveCorridor(Corridor corridor)
    {
        corridors.Remove(corridor);
    }

    public List<Corridor> GetCorridors()
    {
        return corridors;
    }
}
