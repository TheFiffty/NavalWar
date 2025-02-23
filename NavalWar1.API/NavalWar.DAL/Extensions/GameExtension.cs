﻿using NavalWar.DAL.Models;
using NavalWar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL.Extensions
{
    public static class GameExtension
    {
        /// <summary>
        /// change a GameDTo to a Game
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Game ToEntity(this GameDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Game
            {
                Id = dto.Id,
                p1 = dto.p1.Id,
                p2 = dto.p2.Id,
                currentPlayer = dto.currentPlayer,
                hasPlayed= dto.hasPlayed,
                hasTouched= dto.hasTouched,
            };
        }

        /// <summary>
        /// Change a Game to a GameDTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static GameDTO ToDTO(this Game entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new GameDTO
            {
                Id = entity.Id,
                p1 = new PlayerDTO(),
                p2= new PlayerDTO(),
                currentPlayer = entity.currentPlayer,
                hasPlayed = entity.hasPlayed,
                hasTouched = entity.hasTouched,
            };
        }
    }
}
