namespace ProgettoDelVenerdi___Agenzia_Entrate
{
    internal class Contribuente
    {
        // proprietà da settare public perchè verrano utilizzate al di fuori della classe.
        // il contribuente possiede solo proprietà che dovranno essere settate all'interno dei metodi dell'agenziaDelle entrate.
        public string Nome { get; set; }
        public string Cognome { get; set; }

        // stringhe da utilizzare nella data di nascita
        public string Giornonascita { get; set; }
        public string Mesenascita { get; set; }
        public string AnnoNascita { get; set; }

        public string DataDinascitaCompleta { get; set; }
        public string CodiceFiscale { get; set; }

        public int Eta { get; set; }

        // valiabile "nullable" può essere true, false o null
        public bool? IsContribuenteMale { get; set; }
        public string ComuneDiResidenza { get; set; }
        public double RedditoAnnuale { get; set; }

        public bool RegistrazioneInCorso { get; set; }


        // quando ho accumulato tutti i dati in input instanzio la classe e creo un contribuente.
        public Contribuente()
        {
            this.Nome = "";
            this.Cognome = "";
            this.DataDinascitaCompleta = "";
            this.CodiceFiscale = "";
            this.IsContribuenteMale = null;
            this.ComuneDiResidenza = "";
            this.RedditoAnnuale = 0;
            this.RegistrazioneInCorso = false;
            this.Eta = 0;
            this.Giornonascita = "";
            this.Mesenascita = "";
            this.AnnoNascita = "";
        }
    }
}
