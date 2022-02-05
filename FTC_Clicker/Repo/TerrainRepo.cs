using System;
using System.Collections.Generic;
using System.Text;
using FTC_Clicker.Model;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;

namespace FTC_Clicker.Repo
{
    public class TerrainRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public TerrainRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\FTC_Clicker\FTC_Clicker")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Terrain> getAll()
        {
            string sql = "SELECT * FROM terrains";
            if (db.LoadData<Terrain, dynamic>(sql, new { }, connectionString).Count == 0)
                return null;
            return db.LoadData<Terrain, dynamic>(sql, new { }, connectionString);
        }

        public void create(Terrain terrain)
        {
            string sql = "insert into terrains (level, player_id, image) values (@level, @player_id, @image);";

            db.SaveData(sql, new {terrain.Level, terrain.Player_id, terrain.Image}, connectionString);
        }

        public Terrain getById(int id)
        {
            string sql = "select * from terrains where id = @id";
            if (db.LoadData<Terrain, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Terrain, dynamic>(sql, new { id }, connectionString)[0];
        }

        public Terrain getByPlayer_id(int player_id)
        {
            string sql = "select * from terrains where player_id = @player_id";
            if (db.LoadData<Terrain, dynamic>(sql, new { player_id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Terrain, dynamic>(sql, new { player_id }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from terrains where id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateLevelById(int id, int level)
        {
            string sql = "update terrains set level = @level where id = @id";

            db.SaveData(sql, new { level, id }, connectionString);
        }

    }
}
