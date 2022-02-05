using System;
using System.Collections.Generic;
using System.Text;

namespace FTC_Clicker.Model
{
    public class Terrain
    {
        private int id;
        private int level;
        private int player_id;
        private byte[] image;

        public int Id
        {
            get { return id; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Player_id
        {
            get { return player_id; }
            set { player_id = value; }
        }
        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        public Terrain()
        {

        }
        public Terrain(int id, int level, int player_id, byte[] image)
        {
            this.id = id;
            this.level = level;
            this.player_id = player_id;
            this.image = image;
        }

        public Terrain(int level, int player_id, byte[] image)
        {
            this.level = level;
            this.player_id = player_id;
            this.image = image;
        }

        public override bool Equals(object? obj)
        {
            Terrain other = obj as Terrain;
            if (this.id == other.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + " " + level + " " + player_id + " " + image;
        }
    }
}
