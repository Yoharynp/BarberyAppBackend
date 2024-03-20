namespace BappDominio.ObjetosValor.Barbero
{
    public record ApellidoBarbero
    {
        public string Value { get; private set; }
        public ApellidoBarbero(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }

        public static ApellidoBarbero Crear(string value) => new (value);

        public static implicit operator string(ApellidoBarbero value)
        {
            return value.Value;
        }
        public override string ToString()
        {
            return Value;
        }

    }
}