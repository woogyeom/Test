using UnityEngine;
using System.Collections.Generic;

public class DungeonGenerator1 : MonoBehaviour
{
    public int numRooms = 10;
    public int minRoomRadius = 3;
    public int maxRoomRadius = 7;

    public int minDistance = 2;
    public int maxDistance = 5;

    public GameObject tilePrefab;
    public GameObject corridorPrefab;
    
    public List<Room> rooms = new List<Room>();
    private GameObject dungeon;
    public class Room {
        public Vector2Int center;
        public int radius;
        public List<Room> connected;

        public Room(Vector2Int center, int radius) {
            this.center = center;
            this.radius = radius;
            this.connected = new List<Room>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateDungeon(new Vector2Int(0, 0));
        }
    }

    void GenerateDungeon(Vector2Int center)
    {
        ClearDungeon();

        dungeon = new GameObject("Dungeon");
        dungeon.transform.position = new Vector3(center.x, center.y, 0);

        GenerateRooms();
        foreach (Room room in rooms)
        {
            DrawRoom(room, dungeon);
        }
        ConnectRooms(rooms);
    }

    void ClearDungeon()
    {
        if (dungeon != null)
        {
            Destroy(dungeon);
        }
        rooms.Clear();
    }

    void GenerateRooms()
    {
        for (int i = 0; i < numRooms; i++)
        {
            bool roomCollides;
            Room newRoom = null;
            int attempt = 0;
            
            do
            {
                attempt++;
                if (attempt >= 10000) break;
                Vector2Int newCenter = new Vector2Int(Random.Range(-20, 20), Random.Range(-20, 20));
                int newRadius = Random.Range(minRoomRadius, maxRoomRadius + 1);
                newRoom = new Room(newCenter, newRadius);
                roomCollides = false;

                // 새로운 방이 다른 방들과 충돌하는지 확인
                foreach (Room room in rooms)
                {
                    float distance = Vector2Int.Distance(newRoom.center, room.center) - (newRoom.radius + room.radius);
                    if (distance < minDistance) // distance > maxDistance
                    {
                        roomCollides = true;
                        break;
                    }
                }
                
            } while (roomCollides);

            if (newRoom != null) rooms.Add(newRoom);
        }
    }

    void DrawRoom(Room room, GameObject dungeon) {
        string parentName = "Room_" + rooms.IndexOf(room);
        GameObject parentObject = new GameObject(parentName);
        parentObject.transform.parent = dungeon.transform;

        Vector2Int bottomLeft = room.center - new Vector2Int(room.radius, room.radius);

        for (int x = bottomLeft.x; x < bottomLeft.x + room.radius * 2; x++) {
            for (int y = bottomLeft.y; y < bottomLeft.y + room.radius * 2; y++) {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity, parentObject.transform);
            }
        }
    }

    void ConnectRooms(List<Room> rooms) {
        // 연결되지 않은 방들의 목록을 저장하는 리스트로 변경
        Queue<Room> unconnectedRooms = new Queue<Room>(rooms);

        while (unconnectedRooms.Count > 0) {
            Room currentRoom = unconnectedRooms.Dequeue();

            Room nearestConnectedRoom = FindNearestConnectedRoom(currentRoom, unconnectedRooms);
            if (nearestConnectedRoom != null) {
                CreateCorridor(nearestConnectedRoom, currentRoom, false);
                currentRoom.connected.Add(nearestConnectedRoom);
                nearestConnectedRoom.connected.Add(currentRoom);
            }
        }
    }

    Room FindNearestConnectedRoom(Room room, Queue<Room> unconnectedRooms) {
        Room nearestRoom = null;
        float shortestDistance = float.MaxValue;

        foreach (Room unconnectedRoom in unconnectedRooms) {
            if (room == unconnectedRoom)
                continue; // 자기 자신과의 비교는 건너뜁니다.

            float distance = Vector2Int.Distance(room.center, unconnectedRoom.center);
            if (distance < shortestDistance) {
                shortestDistance = distance;
                nearestRoom = unconnectedRoom;
            }
        }

        return nearestRoom;
    }

    void CreateCorridor(Room roomA, Room roomB, bool loop) {
        // 방 A와 B의 중심점을 구합니다.
        Vector2Int start = roomA.center;
        Vector2Int end = roomB.center;

        // A* 알고리즘을 사용하여 경로를 계산합니다.
        List<Vector2Int> path = AStar(start, end);

        // 경로에 노이즈를 추가합니다.
        //AddNoiseToPath(path);

        // 노이즈를 추가한 경로를 사용하여 복도를 생성합니다.
        DrawCorridor(path, roomA, roomB, loop);

        roomA.connected.Add(roomB);
        roomB.connected.Add(roomA);
    }

    List<Vector2Int> AStar(Vector2Int start, Vector2Int end) {
        // 오픈 리스트: 아직 검사하지 않은 노드들의 집합
        List<Vector2Int> openList = new List<Vector2Int>();

        // 닫힌 리스트: 이미 검사한 노드들의 집합
        HashSet<Vector2Int> closedList = new HashSet<Vector2Int>();

        // 시작 노드를 오픈 리스트에 추가
        openList.Add(start);

        // 각 노드까지의 최단 경로를 저장하는 딕셔너리
        Dictionary<Vector2Int, float> gScore = new Dictionary<Vector2Int, float>();
        gScore[start] = 0;

        // 각 노드까지의 예상 최단 경로를 저장하는 딕셔너리
        Dictionary<Vector2Int, float> fScore = new Dictionary<Vector2Int, float>();
        fScore[start] = HeuristicCostEstimate(start, end);

        // 경로를 저장하는 딕셔너리
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();

        while (openList.Count > 0) {
            // 현재 노드 중에서 예상 최단 경로가 가장 짧은 노드를 선택
            Vector2Int current = GetLowestFScoreNode(openList, fScore);

            // 현재 노드가 목표 지점이라면 경로를 반환
            if (current == end) {
                return ReconstructPath(cameFrom, current);
            }

            openList.Remove(current);
            closedList.Add(current);

            // 현재 노드의 이웃 노드들을 검사
            foreach (Vector2Int neighbor in GetNeighbors(current)) {
                if (closedList.Contains(neighbor)) {
                    continue;
                }

                float tentativeGScore = gScore[current] + Vector2Int.Distance(current, neighbor);

                if (!openList.Contains(neighbor)) {
                    openList.Add(neighbor);
                } else if (tentativeGScore >= gScore[neighbor]) {
                    continue;
                }

                // 현재 노드를 거쳐서 neighbor에 도달하는 경로가 더 나은 경로이므로 업데이트
                cameFrom[neighbor] = current;
                gScore[neighbor] = tentativeGScore;
                fScore[neighbor] = gScore[neighbor] + HeuristicCostEstimate(neighbor, end);
            }
        }

        // 경로가 없는 경우 빈 리스트 반환
        return new List<Vector2Int>();
    }

    // 예상 최단 경로를 계산하는 휴리스틱 함수
    float HeuristicCostEstimate(Vector2Int current, Vector2Int goal) {
        return Vector2Int.Distance(current, goal);
    }

    // 예상 최단 경로가 가장 짧은 노드를 반환하는 함수
    Vector2Int GetLowestFScoreNode(List<Vector2Int> openList, Dictionary<Vector2Int, float> fScore) {
        Vector2Int lowestNode = openList[0];
        float lowestFScore = fScore[lowestNode];

        foreach (Vector2Int node in openList) {
            if (fScore[node] < lowestFScore) {
                lowestNode = node;
                lowestFScore = fScore[node];
            }
        }

        return lowestNode;
    }

    // 경로를 재구성하는 함수
    List<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current) {
        List<Vector2Int> path = new List<Vector2Int>();
        path.Add(current);

        while (cameFrom.ContainsKey(current)) {
            current = cameFrom[current];
            path.Add(current);
        }

        path.Reverse();
        return path;
    }

    // 이웃 노드들을 반환하는 함수 (현재는 상하좌우로 이동 가능한 노드들만 반환)
    List<Vector2Int> GetNeighbors(Vector2Int current) {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        neighbors.Add(new Vector2Int(current.x + 1, current.y));
        neighbors.Add(new Vector2Int(current.x - 1, current.y));
        neighbors.Add(new Vector2Int(current.x, current.y + 1));
        neighbors.Add(new Vector2Int(current.x, current.y - 1));

        return neighbors;
    }

    void DrawCorridor(List<Vector2Int> path, Room roomA, Room roomB, bool loop) {
        string prefix = loop ? "Loop_" : "Path_";
        string parentName = prefix + rooms.IndexOf(roomA) + "_" + rooms.IndexOf(roomB);
        GameObject parentObject = new GameObject(parentName);
        parentObject.transform.parent = dungeon.transform;
        foreach (Vector2Int point in path) {
            // 현재 위치에 타일을 배치합니다.
            GameObject tile = Instantiate(corridorPrefab, new Vector3(point.x + 0.5f, point.y + 0.5f, 0), Quaternion.identity, parentObject.transform);
        }
    }
    
}
