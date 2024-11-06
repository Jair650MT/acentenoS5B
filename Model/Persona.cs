using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acentenoS5B.Model
{
    [Table("Persona")]
    public class Persona
       
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [SQLite.MaxLength(25), Unique]
        public string Nombre { get; set; }
    }
}
