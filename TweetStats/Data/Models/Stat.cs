using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TweetStats.Data.Models
{
    public class Stat
    {
        public Stat()
        {

        }

        #region Properties
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int NumOfTweetsRecieved { get; set; }

        [Required]
        public DateTime TimeRecieved { get; set; }

        [Required]
        public int PercentOfTweetsWithEmojis { get; set; }

        [Required]
        public string TopHashtags { get; set; }

        [Required]
        public int PercentOfTweetsWithUrl { get; set; }

        [Required]
        public int PercentofTweetWithImageUrl { get; set; }

        [Required]
        public string TopDomains { get; set; }
        #endregion
    }
}
