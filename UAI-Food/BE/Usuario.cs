﻿namespace BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;

        public Usuario(int getId, string getNombre)
        {
            Id = getId;
            Nombre = getNombre;
        }
    }
}
