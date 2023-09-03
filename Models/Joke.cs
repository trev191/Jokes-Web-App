using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokesWebApp.Models
{
    public class Joke
    {
        public int Id { get; set; }

        [Display(Name = "Joke Question")]
        [DataType(DataType.Text)]
        [Required]
        public string JokeQuestion { get; set; }

        [Display(Name = "Joke Answer")]
        [DataType(DataType.Text)]
        [Required]
        public string JokeAnswer { get; set; }

        [Display(Name = "Creator")]
        [DataType(DataType.Text)]
        public string Creator { get; set; }

        public Joke()
        {
            
        }
    }
}
