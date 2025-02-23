﻿using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using NavalWar.DAL.Interfaces;
using NavalWar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL
{
    public class PlayerRepository : IPlayerRepository
    {
        private NavalWarDBContext _dbContext;
        public PlayerRepository(NavalWarDBContext dBContext)
        {
            _dbContext= dBContext;
        }

        #region GET
        public IEnumerable<PlayerDTO> Get()
        {
            try
            {
               return _dbContext.Players.ToList().Select(p => p.ToDTO()).ToList();
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public PlayerDTO Get(int id)
        {
            try
            {
                return _dbContext.Players.FirstOrDefault(p => p.Id == id).ToDTO();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region POST
        public bool Add(PlayerDTO player)
        {
            var isAdded = false;
            try
            {
                var entity = player.ToEntity();
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                isAdded = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return isAdded;
        }
        #endregion

        #region PUT
        public bool Update(PlayerDTO player)
        {
            try
            {
                var entity = player.ToEntity();
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
        #endregion

        #region DELETE
        public bool Remove(PlayerDTO player)
        {
            try
            {
                var entity = player.ToEntity();

                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                }

                _dbContext.Players.Remove(entity);

                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
        #endregion
    }
}
