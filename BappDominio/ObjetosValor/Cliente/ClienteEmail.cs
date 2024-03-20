namespace BappDominio.ObjetosValor.Cliente
{
    public record ClienteEmail
    {
        public string Value { get; private set; }
        public ClienteEmail(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }


        public static ClienteEmail Crear(string value)
        {
            return new ClienteEmail(value);
        }

        public static implicit operator string(ClienteEmail value)
        {
            return value.Value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}