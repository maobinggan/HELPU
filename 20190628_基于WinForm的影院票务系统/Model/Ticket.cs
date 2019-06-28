using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Ticket
    {
        public int Id { get; set; }
        public string movieName { get; set; }
        public string date { get; set; }
        public string price { get; set; }

        public Ticket()
        {
        }

        public Ticket(int id)
        {
            Id = id;
        }

        public Ticket(string movieName, string date, string price)
        {
            this.movieName = movieName;
            this.date = date;
            this.price = price;
        }

        public Ticket(int id, string movieName, string date, string price) : this(id)
        {
            this.movieName = movieName;
            this.date = date;
            this.price = price;
        }
    }
}
