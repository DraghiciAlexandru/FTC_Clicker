using System;
using System.Collections.Generic;
using System.Text;
using FTC_Clicker.Exceptions;
using FTC_Clicker.Model;
using FTC_Clicker.Repo;

namespace FTC_Clicker.Services
{
    class TerrainServices
    {
        private TerrainRepo terrainRepo;

        private List<Terrain> terrains;
        public TerrainServices()
        {
            terrainRepo = new TerrainRepo();
            terrains = terrainRepo.getAll();
        }

        public void create(Terrain terrain)
        {
            if (!terrains.Contains(terrain))
            {
                terrainRepo.create(terrain);
            }
            else
            {
                throw new ClickerException("Terrain already exists");
            }
        }

        public List<Terrain> getAll()
        {
            if (terrains == null || terrains.Count == 0) 
                return null;
            return terrains;
        }

        public Terrain getById(int id)
        {
            if (id >= 1)
            {
                return terrainRepo.getById(id);
            }
            else
            {
                throw new ClickerException("Invalid terrain id 2");
            }
        }
        
        public Terrain getByPlayer_id(int player_id)
        {
            return terrainRepo.getByPlayer_id(player_id);
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                terrainRepo.deleteById(id);
            }
            else
            {
                throw new ClickerException("Invalid terrain id 3");
            }
        }

        public void updateTypeById(int id, int level)
        {
            if (id > 0 && level > 0)
            {
                terrainRepo.updateLevelById(id, level);
            }
            else
            {
                throw new ClickerException("Invalid data");
            }
        }
    }
}
