using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempleOfDoomData.Factories;
using TempleOfDoomModel;
using System.Text.Json;
using System.IO;
using TempleOfDoomModel.Doors;


namespace TempleOfDoomData
{
    public class GameFileReader
    {
        private readonly ILevelDataReader _levelDataReader;
        private readonly RoomFactory _roomFactory;
        private readonly ConnectionFactory _connectionFactory;

        public GameFileReader(ILevelDataReader levelDataReader, RoomFactory roomFactory, ConnectionFactory connectionFactory)
        {
            _levelDataReader = levelDataReader;
            _roomFactory = roomFactory;
            _connectionFactory = connectionFactory;
        }

        public Game ReadGame(string filePath)
        {
            RootobjectDTO gameData = _levelDataReader.ReadLevelData(filePath);
            Game game = new Game(filePath);

            List<Room> rooms = gameData.rooms.Select(dto => _roomFactory.CreateRoom(dto)).ToList();
            _connectionFactory.CreateConnections(rooms, gameData.connections);

            game.player = ConvertToPlayer(gameData.player, rooms);

            return game;
        }

        private RootobjectDTO ParseJson(string jsonFilePath)
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<RootobjectDTO>(jsonContent);
        }

        private Player ConvertToPlayer(PlayerDTO playerDTO, List<Room> rooms)
        {
            Room startRoom = rooms.ElementAtOrDefault(playerDTO.startRoomId - 1);
            if (startRoom == null)
            {
                throw new InvalidOperationException("Start room for player not found.");
            }

            Position startPosition = new Position(playerDTO.startX, playerDTO.startY);
            var player = new Player(startPosition, startRoom)
            {
                _lives = playerDTO.lives
            };

            return player;
        }
    }


}
