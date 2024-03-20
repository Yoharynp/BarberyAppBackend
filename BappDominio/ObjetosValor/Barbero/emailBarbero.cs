namespace BappDominio.ObjetosValor.Barbero
{
    public record EmailBarbero
    {
        public string Value { get; private set; }
        public EmailBarbero(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }

        public static EmailBarbero Crear(string value)
        {
            return new EmailBarbero(value);
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(EmailBarbero value)
        {
            return value.Value;

        }
    }
}