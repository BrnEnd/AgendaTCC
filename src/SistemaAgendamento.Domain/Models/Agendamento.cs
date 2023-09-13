using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Domain.Models
{
    public class Agendamento
    {

        public Guid IdAgendamento { get; set; }

        private DateTime _diaHoraAgendamento;
        public DateTime DiaHoraAgendamento
        {
            get => this._diaHoraAgendamento; private set
            {
                //if (value < DateTime.UtcNow)
                //{
                  //  throw new Exception("Data de agendamento inferior a data atual.");
                //}
                //else
                //{
                    this._diaHoraAgendamento = value;
                //}
            }
        }
        public int StatusAgendamento { get; set; }

        public int ClienteIdCliente { get; set; }
        public int AgendaIdAgenda { get; set; }
        public Cliente Cliente { get; set; }
        public Agenda Agenda { get; set; }
        public Agendamento(Guid idAgendamento, DateTime diaHoraAgendamento, int statusAgendamento)
        {
            IdAgendamento = idAgendamento;
            DiaHoraAgendamento = diaHoraAgendamento;
            StatusAgendamento = statusAgendamento;

        }

    }
}
