using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_28.Models
{
    public class CardDeck
    {
        public bool shuffled { get; set; }

        public bool success { get; set; }

        public string deck_Id { get; set; }

        public int remaining { get; set; }
    }
}
