namespace BappDominio.ObjetosValor.LocalBarbero
{
    public record NombreLocal
    {
        public string Value { get; private set; }
        public NombreLocal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }

        public static NombreLocal Crear(string value)
        {
            return new NombreLocal(value);
        }

        public static implicit operator string(NombreLocal value) => value.Value;

        public override string ToString()
        {
            return Value;
        }
    }
}
