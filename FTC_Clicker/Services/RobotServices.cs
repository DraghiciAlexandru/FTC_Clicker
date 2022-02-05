using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using FTC_Clicker.Exceptions;
using FTC_Clicker.Model;
using FTC_Clicker.Repo;

namespace FTC_Clicker.Services
{
    public class RobotServices
    {
        private RobotRepo robotRepo;

        private List<Robot> robots;
        public RobotServices()
        {
            robotRepo = new RobotRepo();
            robots = robotRepo.getAll();
        }

        public void create(Robot robot)
        {
            if (!robots.Contains(robot))
            {
                robotRepo.create(robot);
            }
            else
            {
                throw new ClickerException("Robot already exists");
            }
        }

        public List<Robot> getAll()
        {
            if (robots == null || robots.Count == 0) 
                return null;
            return robots;
        }

        public Robot getById(int id)
        {
            if (id >= 1)
            {
                return robotRepo.getById(id);
            }
            else
            {
                throw new ClickerException("Invalid player id 2");
            }
        }

        public Robot getByTerrain_id(int terrain_id)
        {
            return robotRepo.getByTerrain_id(terrain_id);
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                robotRepo.deleteById(id);
            }
            else
            {
                throw new ClickerException("Invalid player id 3");
            }
        }

        public void updateTypeById(int id, int type)
        {
            if (id > 0 && type > 0)
            {
                robotRepo.updateTypeById(id, type);
            }
            else
            {
                throw new ClickerException("Invalid data");
            }
        }
    }
}
