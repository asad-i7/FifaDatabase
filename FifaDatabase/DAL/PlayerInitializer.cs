using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FifaDatabase.Models;

namespace FifaDatabase.DAL
{
    public class PlayerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PlayerContext>
    {
        protected override void Seed(PlayerContext context)
        {
            var players = new List<Player>
            {
                 new Player{Rating=94, Name="Cristiano Ronaldo", Position="LW", Club="Real Madrid", League="La Liga Santander", Nation = "Portugal", Age=31, Height=185, Workrates="High/Low", Pace=92, Shooting=92, Passing=81, Dribbling=91, Defending=33, Physical=80, Traits="Takes Powerful Driven Free Kicks, Flair, Long Shot Taker, Speed Dribbler.", Specialities="Speedster, Dribbler, Distance Shooter, Acrobat, Clinical Finisher, Complete Forward, Poacher.", Description="", Image="", Card=""},
            };

            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();

        }
    }
}