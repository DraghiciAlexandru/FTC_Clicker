using System;
using System.Collections.Generic;
using System.Text;
using FTC_Clicker.Model;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;

namespace FTC_Clicker.Repo
{
    public class RobotRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public RobotRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\FTC_Clicker\FTC_Clicker")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Robot> getAll()
        {
            string sql = "SELECT * FROM robots";
            if (db.LoadData<Robot, dynamic>(sql, new { }, connectionString).Count == 0)
                return null;
            return db.LoadData<Robot, dynamic>(sql, new { }, connectionString);
        }

        public void create(Robot robot)
        {
            string sql = "insert into robots (type, terrain_id, image) values (@type, @terrain_id, @image);";

            db.SaveData(sql, new {robot.Type, robot.Terrain_id, robot.Image}, connectionString);
        }

        public Robot getById(int id)
        {
            string sql = "select * from robots where id = @id";
            if (db.LoadData<Robot, dynamic>(sql, new {id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Robot, dynamic>(sql, new {id}, connectionString)[0];
        }

        public Robot getByTerrain_id(int terrain_id)
        {
            string sql = "select * from robots where terrain_id = @terrain_id";
            if (db.LoadData<Robot, dynamic>(sql, new {terrain_id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Robot, dynamic>(sql, new {terrain_id}, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from robots where id = @id";

            db.SaveData(sql, new {id}, connectionString);
        }

        public void updateTypeById(int id, int type)
        {
            string sql = "update robots set type = @type where id = @id";

            db.SaveData(sql, new {type, id}, connectionString);
        }
    }
}
