using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using FTC_Clicker.Exceptions;
using FTC_Clicker.Model;
using FTC_Clicker.Repo;

namespace FTC_Clicker.Services
{
    public class PlayerServices
    {
        private PlayerRepo playerRepo;

        public static Player loged;

        private List<Player> players;
        public PlayerServices()
        {
            playerRepo = new PlayerRepo();
            players = playerRepo.getAll();
        }

        public void create(Player student)
        {
            if (!players.Contains(student))
            {
                playerRepo.create(student);
            }
            else
            {
                throw new ClickerException("Player already exists");
            }
        }

        public List<Player> getAll()
        {
            if (players == null || players.Count == 0) 
                return null;
            return players;
        }

        public Player getById(int id)
        {
            if (id >= 1)
            {
                return playerRepo.getById(id);
            }
            else
            {
                throw new ClickerException("Invalid player id 2");
            }
        }

        public Player getByEmail(String email)
        {
            return playerRepo.getByEmail(email);
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                playerRepo.deleteById(id);
            }
            else
            {
                throw new ClickerException("Invalid player id 3");
            }
        }

        public void updateNameById(int id, string name)
        {
            if (id > 0 && name.Trim(' ').Length > 0)
            {
                playerRepo.updateNameById(id, name);
            }
            else
            {
                throw new ClickerException("Invalid data");
            }
        }

        public void updateEmailById(int id, string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);

                if (id > 0)
                {
                    int flag = 0;
                    for (int i = 0; i < players.Count; i++)
                        if (players[i].Email == email)
                            flag = 1;
                    if (flag == 0)
                        playerRepo.updateEmailById(id, email);
                    else
                    {
                        throw new ClickerException("Email already exists");
                    }
                }
                else
                {
                    throw new ClickerException("Invalid id");
                }
            }
            catch
            {
                throw new ClickerException("Invalid email");
            }
        }

        public void updateBalanceById(int id, int balance)
        {
            if (id > 0 && balance > 0)
            {
                playerRepo.updateBalanceById(id, balance);
            }
            else
            {
                throw new ClickerException("Invalid data");
            }
        }
    }
}
