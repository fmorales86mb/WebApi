using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class ReservasModel
    {
        public ReservasModel()
        {
            this.Reservas = new List<ReservaModel>();
        }

        public ReservasModel(List<Reserva> data): this()
        {
            foreach(Reserva r in data)
            {
                this.Reservas.Add(this.MapDataToModel(r));
            }
        }

        public List<ReservaModel> Reservas { get; set; }

        private ReservaModel MapDataToModel(Reserva data)
        {
            return new ReservaModel()
            {
                Fecha = data.d.ToShortDateString(),
                Monto = data.v.ToString()
            };
        }
    }
}
