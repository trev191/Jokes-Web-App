﻿namespace JokesWebApp.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }
        public string Creator { get; set; }
        public Joke()
        {
            
        }
    }
}
