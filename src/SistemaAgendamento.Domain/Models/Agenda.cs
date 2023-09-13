using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Domain.Models
{
    public class Agenda
    {
        private int _idAgenda;
        public int IdAgenda
        {
            get => this._idAgenda; private set
            {
                if (value <= 0)
                {
                    throw new Exception("Necessario IDAgenda para instancia do Objeto Agenda.");
                }
                else
                {
                    this._idAgenda = value;
                }
            }
        }

        public char AgendaAberta { get; set; }

        public List<Agendamento> Agendamentos { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public Agenda(int idAgenda, char agendaAberta)
        {
            IdAgenda = idAgenda;

            AgendaAberta = agendaAberta;

        }


    }
}
