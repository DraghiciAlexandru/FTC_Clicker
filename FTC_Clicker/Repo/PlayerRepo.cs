using System;
using System.Collections.Generic;
using System.Text;
using FTC_Clicker.Model;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;

namespace FTC_Clicker.Repo
{
    public class PlayerRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public PlayerRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\FTC_Clicker\FTC_Clicker")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Player> getAll()
        {
            string sql = "SELECT * FROM player";
            if (db.LoadData<Player, dynamic>(sql, new { }, connectionString).Count == 0)
                return null;
            return db.LoadData<Player, dynamic>(sql, new { }, connectionString);
        }

        public List<Player> getTeamNumber(string teamNumber)
        {
            string sql = "SELECT * FROM player where teamNumber = @teamNumber";
            if (db.LoadData<Player, dynamic>(sql, new { teamNumber }, connectionString).Count == 0)
                return null;
            return db.LoadData<Player, dynamic>(sql, new { teamNumber }, connectionString);
        }

        public void create(Player student)
        {
            string sql = "insert into player (teamNumber, name, password, email, balance) values (@teamNumber, @name, @password, @email, @balance);";

            db.SaveData(sql, new {student.TeamNumber, student.Name, student.Password, student.Email, student.Balance},
                connectionString);
        }

        public Player getByName(string name)
        {
            string sql = "select * from player where name like '*@name*'";

            if (db.LoadData<Player, dynamic>(sql, new {name}, connectionString).Count == 0)
                return null;
            return db.LoadData<Player, dynamic>(sql, new {name}, connectionString)[0];
        }

        public Player getById(int id)
        {
            string sql = "select * from player where id = @id";
            if (db.LoadData<Player, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Player, dynamic>(sql, new { id }, connectionString)[0];
        }

        public Player getByEmail(String email)
        {
            string sql = "select * from player where email = @email";
            if (db.LoadData<Player, dynamic>(sql, new { email }, connectionString).Count == 0)
                return null;
            return db.LoadData<Player, dynamic>(sql, new { email }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from player where id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void deleteByName(string name)
        {
            string sql = "delete from player where name=@name";
            db.SaveData(sql, new { name }, connectionString);
        }

        public void updateNameById(int id, string name)
        {
            string sql = "update player set name = @name where id = @id";

            db.SaveData(sql, new { name, id }, connectionString);
        }

        public void updateBalanceById(int id, int balance)
        {
            string sql = "update player set balance = @balance where id = @id";

            db.SaveData(sql, new { balance, id }, connectionString);
        }

        public void updateEmailById(int id, string email)
        {
            string sql = "update player set email=@email where id=@id";

            db.SaveData(sql, new { email, id }, connectionString);
        }

    }
}
