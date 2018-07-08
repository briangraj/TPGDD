using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrbaHotel.Utilidades;
using System.Data.SqlClient;

namespace FrbaHotel.Entidades
{
    public class Reserva
    {
        public DateTime fechaDeReserva;
        public DateTime fechaInicio;
        public DateTime fechaFin;
        public string descRegimen;
        public string tipoHabitacion;
        public Usuario usuario;
        public int id;

        public List<Habitacion> habitaciones = new List<Habitacion>();

        public Reserva(DateTime fechaInicio, DateTime fechaFin, string tipoHabitacion, string descRegimen, Usuario usuario)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.tipoHabitacion = tipoHabitacion;
            this.descRegimen = descRegimen;
            this.usuario = usuario;
        }

        public Reserva(int id)
        {
            this.id = id;
        }

        public void cargar()
        {
            //todo esto habria que cambiarlo si ponemos tipo_hab en otra tabla
            DB.ejecutarReader(
                "SELECT Fecha_Reserva, Fecha_Inicio, Fecha_Fin, rg.Descripcion, th.Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Reserva rv " +
                    "JOIN LA_QUERY_DE_PAPEL.Regimen rg ON rv.Id_Regimen = rg.Id_Regimen " +
                    "JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON rv.Id_Reserva = rh.Id_Reserva " +
                    "JOIN LA_QUERY_DE_PAPEL.Habitacion h ON rh.Nro_Habitacion = h.Nro_Habitacion AND rh.Id_Hotel = h.Id_Hotel " +
                    "JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo " +
                    "WHERE rv.Id_Reserva = @idReserva",
                    cargarReserva, "idReserva", this.id);
            

        }

        public void cargarReserva(SqlDataReader reader)
        {
            if(!reader.Read())
                throw new Exception("No existe la reserva");

            this.fechaDeReserva = reader.GetDateTime(0);
            this.fechaInicio = reader.GetDateTime(1);
            this.fechaFin = reader.GetDateTime(2);
            this.descRegimen = reader.GetString(3);
            this.tipoHabitacion = reader.GetString(4);
        }
    }
}
