namespace GTGatoFortunna.Models
{
    public class Result<T> where T: class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ErrorLine { get; set; }
        public string InnerExeption { get; set; }
        public T Resultado { get; set; }
    }

    public class LogAction
    {
        public string Tabla { get; set; }
        public string Resultado { get; set; }
    }

}
