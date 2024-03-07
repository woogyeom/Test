using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : Area
{
    private Room startRoom;
    private Room endRoom;
    
    public Corridor(Room startRoom, Room endRoom) : base()
    {
        this.startRoom = startRoom;
        this.endRoom = endRoom; 
    }

}
