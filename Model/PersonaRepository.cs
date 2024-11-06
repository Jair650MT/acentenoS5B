using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acentenoS5B.Model
{
    
    public class PersonaRepository
    {
        string _dbPath;//ruta
        private SQLiteConnection conn;

        //Mensaje mostrar
        public string statusMessage {  get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();  
        }

        public PersonaRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void addNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");

                Persona person = new Persona { Nombre = nombre };
                result = conn.Insert(person);

                statusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
            }
        }
        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Failed to retrieve data: {0}", ex.Message);
            }
            return new List<Persona>();
        }

        // Método para actualizar una persona existente
        public void UpdatePerson(int id, string nombre)
        {
            try
            {
                Init();

                var person = conn.Find<Persona>(id);
                if (person == null)
                    throw new Exception("Persona no encontrada");

                person.Nombre = nombre;
                int result = conn.Update(person);

                statusMessage = string.Format("{0} registro(s) actualizado(s) (ID: {1}, Nombre: {2})", result, id, nombre);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("No se pudo actualizar la persona con ID {0}. Error: {1}", id, ex.Message);
            }
        }

        // Método para eliminar una persona existente
        public void DeletePerson(int id)
        {
            try
            {
                Init();

                var person = conn.Find<Persona>(id);
                if (person == null)
                    throw new Exception("Persona no encontrada");

                int result = conn.Delete(person);

                statusMessage = string.Format("{0} registro(s) eliminado(s) (ID: {1})", result, id);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("No se pudo eliminar la persona con ID {0}. Error: {1}", id, ex.Message);
            }
        }

    }
}
