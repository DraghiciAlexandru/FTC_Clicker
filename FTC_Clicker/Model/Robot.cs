using System;
using System.Collections.Generic;
using System.Text;

namespace FTC_Clicker.Model
{
    public class Robot
    {
        private int id;
        private int type;
        private int terrain_id;
        private byte[] image;

        public int Id
        {
            get { return id; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Terrain_id
        {
            get { return terrain_id; }
            set { terrain_id = value; }
        }
        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        public Robot()
        {

        }

        public Robot(int id, int type, int terrainId, byte[] image)
        {
            this.id = id;
            this.type = type;
            this.terrain_id = terrainId;
            this.image = image;
        }

        public Robot(int type, int terrainId, byte[] image)
        {
            this.type = type;
            this.terrain_id = terrainId;
            this.image = image;
        }

        public override bool Equals(object? obj)
        {
            Robot other = obj as Robot;
            if (this.id == other.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + " " + type + " " + terrain_id + " " + image;
        }
    }
}
