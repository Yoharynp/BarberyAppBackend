namespace BappDominio.ObjetosValor.Cliente
{
    public record ClienteContraseña
    {
        public string Value { get; private set; }
        public ClienteContraseña(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }

        public static ClienteContraseña Crear(string value)
        {
            return new ClienteContraseña(value);
        }

        public static implicit operator string(ClienteContraseña value)
        {
            return value.Value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}