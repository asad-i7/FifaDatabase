using System;
using System.Collections.Generic;

namespace FifaDatabase.Models
{
    public class Player
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public string League { get; set; }
        public string Nation { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string Workrates { get; set; }
        public int Pace { get; set; }
        public int Shooting { get; set; }
        public int Dribbling { get; set; }
        public int Passing { get; set; }
        public int Defending { get; set; }
        public int Physical { get; set; }
        public string Traits { get; set; }
        public string Specialities { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Card { get; set; }
    }
}