using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TweetStats.Data.Models
{
    class Emojis
    {
        public Emojis()
        {

        }

        #region Properties
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Emoji{ get; set; }
        #endregion
    }
}
