namespace ControleDeBar.Model
{
    public class FaturamentoViewModel
    {
        public List<Comanda> Comandas { get; set; }

        //Tudo aquilo que foi pago
        public double TotalFaturado { get; set; }
        public double TotalPendente { get; set; }

        //Somada do TotalCusto das comandas
        public double CustoTotal { get; set; }

        public double LucroTotal { get; set; }
    }
}
