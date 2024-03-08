using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSP
{
    BSPNode dungeonNode;
    public BSP(Dungeon dungeon)
    {
        Vector2Int topLeft = dungeon.GetTopLeft();
        int width = dungeon.GetWidth();
        int height = dungeon.GetHeight();
        dungeonNode = new BSPNode(topLeft, width, height);
    }

    public void SplitDungeon()
    {
        
    }

    private void Split(BSPNode node)
    {
        int width = node.GetWidth();
        int height = node.GetHeight();

        if (width > height)
        {

        }
        else if (height > width)
        {

        }
        else
        {

        }
    }

    private void SplitVertical()
    {

    }

    private void SplitHorizontal()
    {

    }

    
}

class BSPNode
{
    private Vector2Int topLeft;
    private Vector2Int botRight;
    private int width;
    private int height;

    public BSPNode(Vector2Int topLeft, int width, int height)
    {
        this.topLeft = topLeft;
        this.botRight = new Vector2Int(topLeft.x + width, topLeft.y + height);
        this.width = width;
        this.height = height;
    }

    public Vector2Int GetTopLeft()
    {
        return topLeft;
    }

    public Vector2Int GetBotRight()
    {
        return botRight;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
}