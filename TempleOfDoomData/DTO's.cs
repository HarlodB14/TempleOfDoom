namespace TempleOfDoomData
{

    public class RootobjectDTO
    {
        public List<RoomDTO> rooms { get; set; }
        public List<ConnectionDTO> connections { get; set; }
        public PlayerDTO player { get; set; }
    }

    public class PlayerDTO
    {
        public int startRoomId { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int lives { get; set; }
    }

    public class RoomDTO
    {
        public int id { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<ItemDTO> items { get; set; }
    }

    public class ItemDTO
    {
        public string type { get; set; }
        public int damage { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string color { get; set; }
    }

    public class ConnectionDTO
    {
        public int NORTH { get; set; }
        public int SOUTH { get; set; }
        public List<DoorDTO> doors { get; set; }
        public int WEST { get; set; }
        public int EAST { get; set; }
    }

    public class DoorDTO
    {
        public string type { get; set; }
        public string color { get; set; }
        public int no_of_stones { get; set; }
    }
}
