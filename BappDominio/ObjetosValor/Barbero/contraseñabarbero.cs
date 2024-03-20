namespace BappDominio.ObjetosValor.Barbero
{
    public record Contraseñabarbero
    {
        public string Value { get; private set; }
        public Contraseñabarbero(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }

        public static Contraseñabarbero Crear(string value)
        {
            return new Contraseñabarbero(value);
        }


        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(Contraseñabarbero contraseñabarbero) => contraseñabarbero.Value;
    }
}