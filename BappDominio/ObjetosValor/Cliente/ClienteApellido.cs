namespace BappDominio.ObjetosValor.Cliente
{
    public record ClienteApellido
    {
        public string Value { get; private set; }
        public ClienteApellido(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }


        public static ClienteApellido Crear(string value)
        {
            return new ClienteApellido(value);
        }

        public static implicit operator string(ClienteApellido value)
        {
            return value.Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}