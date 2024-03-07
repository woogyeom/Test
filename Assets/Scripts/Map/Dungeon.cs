using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    private List<Room> rooms;
    private List<Corridor> corridors;

    public Dungeon()
    {
        rooms = new List<Room>();
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
