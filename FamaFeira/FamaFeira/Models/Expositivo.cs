namespace FamaFeira.Models
{
    public class Expositivo
    {
        public bool expositivo { get; set; }

        public Expositivo(string expositivo)
        {
            if (expositivo.Equals("True")) this.expositivo = true;
            else this.expositivo = false;
        }

        public bool getExpositivo()
        {
            return this.expositivo;
        }

    }
}