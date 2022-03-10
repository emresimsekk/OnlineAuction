using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.UI.ViewsModel
{
    public class AuctionViewModel
    {
        
        public string Id { get; set; }

        [Required(ErrorMessage = "Please Fill Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill Descrpiton")]
        public string Descrpiton { get; set; }

        [Required(ErrorMessage = "Please Fill Product")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Please Fill Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Fill Start Date")]
        public DateTime StartedAt { get; set; }

        [Required(ErrorMessage = "Please Fill Finish Date")]
        public DateTime FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }

        public int SellerId { get; set; }
        public List<string> IncludedSeller { get; set; }
    }
}
