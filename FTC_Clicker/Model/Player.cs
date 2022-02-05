using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FTC_Clicker.Model
{
    public class Player
    {
        private int id;
        private String teamNumber;
        private String name;
        private String password;
        private String email;
        private BigInteger balance = 0;

        public int Id
        {
            get { return id; }
        }
        public String TeamNumber
        {
            get { return teamNumber; }
            set { teamNumber = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public BigInteger Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Player()
        {

        }

        public Player(int id, String teamNumber, String name, String password, String email, BigInteger balance)
        {
            this.id = id;
            this.teamNumber = teamNumber;
            this.name = name;
            this.password = password;
            this.email = email;
            this.balance = balance;
        }

        public Player(String teamNumber, String name, String password, String email, BigInteger balance)
        {
            this.teamNumber = teamNumber;
            this.name = name;
            this.password = password;
            this.email = email;
            this.balance = balance;
        }

        public override bool Equals(object? obj)
        {
            Player other = obj as Player;
            if ((this.id == other.id) || (this.name == other.name && this.teamNumber == other.teamNumber) ||
                (this.email == other.email && this.password == other.password)) 
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + teamNumber + "," + name + "," + password + "," + email + "," + balance;
        }
    }
}
