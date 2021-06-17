using heroesCompanyAngular.Models;
using Md_exercise.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace heroesCompanyAngular.Models {
    public enum Color { Red, Green, Blue, White, Black, Yellow, Grey }
    public class Hero : Ientity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsAttacker { get; set; }
        //public string GuidId { get; set; }
        public DateTime InitialTrainDate { get; set; }
        [Required]
        public Color SuitColor { get; set; }
        public decimal StartingPower { get; set; }
        public decimal CurrentPower { get; set; }
        public DateTime TrainedDate { get; set; }
        public byte TrainedCount { get; set; }
        public virtual ApplicationUser Trainer { get; set; }

    }
}