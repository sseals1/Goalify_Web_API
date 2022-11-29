using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Goalify.Models
{
    public class Goals
    {       
            public int Id { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public int UserId { get; set; }

            [Required]
            [StringLength(255, MinimumLength = 3)]
            public int CategoryId { get; set; }

            public int PriorityId { get; set; }
        public int TermId { get; set; } 
        public int MilestoneId { get; set; }    
        public string GoalDescription { get; set; }
        public string GoalObjectives    { get; set; }
        public string Notes { get; set; }   
        public DateTime Date { get; set; }  
        
        }
    
}

