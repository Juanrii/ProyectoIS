﻿
namespace BE
{
    public class BECliente
    {
    #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    #endregion

    #region Constructores
        public BECliente() { }

        public BECliente(int id, string nombre, string apellido, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }
    #endregion
    }
}
