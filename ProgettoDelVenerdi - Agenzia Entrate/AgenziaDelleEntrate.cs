using System;
using System.Threading;

namespace ProgettoDelVenerdi___Agenzia_Entrate
{
    internal static class AgenziaDelleEntrate
    {
        //Agenzia delle entrate sara static e conterrà solo i metodi per gestire le proprietà del contribuente.

        /*
         * summary: vengono chiesti alcuni parametri iniziali (nome cognome eta sesso) per personalizzare la risposta del sistema 
         * parametri: viene passato l'intero oggetto contribuente per fare il set di alcune delle sue proprietà
         * return: void
         */
        public static void Benvenuto(Contribuente contribuente)
        {
            Console.WriteLine("Inserisci il tuo nome.");
            string nomeUtente = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo cognome.");
            string cognomeUtente = Console.ReadLine();

            contribuente.Nome = nomeUtente;
            contribuente.Cognome = cognomeUtente;

        inserisciSesso:
            Console.WriteLine("Inserisci il tuo sesso:  m/f");
            string sesso = Console.ReadLine().Trim();
            if (sesso == "m")
            {
                // salva true nel boolean del sesso
                contribuente.IsContribuenteMale = true;
                Console.WriteLine("Abbiamo salvato la tua scelta.");
            }
            else if (sesso == "f")
            {
                // salva false nel boolean del sesso
                contribuente.IsContribuenteMale = false;
                Console.WriteLine("Abbiamo salvato la tua scelta.");
            }
            else
            {
                Console.WriteLine("input non valido. Riprova.");
                goto inserisciSesso;
            }

        InserisciEta:
            Console.WriteLine("Inserisci la tua età:");

            try
            {
                int etaUtente = Convert.ToInt32(Console.ReadLine());
                if (etaUtente <= 0)
                {
                    Console.WriteLine("Input non valido. Riprova.");
                    goto InserisciEta;
                }
                else if (etaUtente < 16)
                {
                    Console.WriteLine("Devi avere almeno 16 anni per il calcolo delle tasse.");
                    goto InserisciEta;
                }
                else if (etaUtente >= 16)
                {
                    contribuente.Eta = etaUtente;
                    Console.WriteLine("Eta inserita con successo.");
                    Benvenuto2(contribuente);
                }
            }
            catch
            {
                Console.WriteLine("input non valido. Riprova");
                goto InserisciEta;
            }

        }

        /*
       * summary: i parametri acquisiti in precedenza vengono utilizzati per personalizzare la risposta del sistema 
       * parametri: viene passato l'intero oggetto contribuente per fare un check delle sue proprietà
       * return: void
       */
        public static void Benvenuto2(Contribuente contribuente)
        {
            if (contribuente.IsContribuenteMale == true && contribuente.Eta > 35)
            {
                Console.WriteLine($"Benvenuto Nell'Agenzia delle Entrate Sig. {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
            else if ((contribuente.IsContribuenteMale == true && contribuente.Eta < 35))
            {
                Console.WriteLine($"Benvenuta Nell'Agenzia delle Entrate Signorino {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
            else if ((contribuente.IsContribuenteMale == false && contribuente.Eta > 35))
            {
                Console.WriteLine($"Benvenuto Nell'Agenzia delle Entrate Signora {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
            else if ((contribuente.IsContribuenteMale == false && contribuente.Eta < 35))
            {
                Console.WriteLine($"Benvenuto Nell'Agenzia delle Entrate Signorina {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
        }

        /*
      * summary: menu iniziale, da qi partono le scelte dell utente sul cosa fare, continuare con la registrazione oppure uscire dal programma
      * parametri: viene passato l'intero oggetto contribuente 
      * return: void
      */
        public static void Menu(Contribuente contribuente)
        {
        RipetiMenu:
            Console.WriteLine("=========================================");
            Console.WriteLine("Scegli cosa Fare:");
            Console.WriteLine("1- Registrati:");
            Console.WriteLine("2- Esci");
            Console.WriteLine("=========================================");

            int scelta = Convert.ToInt32(Console.ReadLine());
            if (scelta == 1 || scelta == 2)
            {
                if (scelta == 1)
                {
                    Console.WriteLine("Procediamo con l'acquisizione dei dati necessari al calcolo delle tasse...");
                    Thread.Sleep(4000);
                    Registrati(contribuente);
                }
                else
                {
                    Esci(contribuente);
                }
            }
            else
            {
                Console.WriteLine("input non valido. Riprova");
                goto RipetiMenu;
            }
        }


        /*
    * summary: 
    * parametri:
    * return: 
    */
        public static void Registrati(Contribuente contribuente)
        {
            contribuente.RegistrazioneInCorso = true;
            SetMesenascita(contribuente);
            SetGiornoNascita(contribuente);
            SetAnnoDinascita(contribuente);
            SetDataNascitaCompleta(contribuente);
            SetCodiceFiscale(contribuente);
            SetComunediResidenza(contribuente);
            SetRedditoAnnuale(contribuente);
            CalcolotasseImposte(contribuente);

        }


        public static string SetMesenascita(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

        // setto il mese: 

        SetDelMeseDINascita:
            Console.WriteLine("inserisci il mese di nascita in formato numero: (1/12)");
            Thread.Sleep(2000);

            try
            {
                int meseANumero = Convert.ToInt32(Console.ReadLine());
                string meseAStringa = "";
                if (meseANumero >= 1 && meseANumero <= 12)
                {
                    // trasformalo in formato stringa 
                    switch (meseANumero)
                    {
                        case 1: meseAStringa = "Gennaio"; break;
                        case 2: meseAStringa = "Febbraio"; break;
                        case 3: meseAStringa = "marzo"; break;
                        case 4: meseAStringa = "Aprile"; break;
                        case 5: meseAStringa = "Maggio"; break;
                        case 6: meseAStringa = "Giugno"; break;
                        case 7: meseAStringa = "Luglio"; break;
                        case 8: meseAStringa = "Agosto"; break;
                        case 9: meseAStringa = "Settembre"; break;
                        case 10: meseAStringa = "Ottobre"; break;
                        case 11: meseAStringa = "Novembre"; break;
                        case 12: meseAStringa = "Dicembre"; break;
                    }
                }
                else
                {
                    Console.WriteLine("formato non valido. Riprova.");
                    goto SetDelMeseDINascita;
                }

                Console.WriteLine($"il tuo mese di nascita è stato impostato su: {meseAStringa} ");
                return contribuente.Mesenascita = meseAStringa;

            }
            catch
            {

                Console.WriteLine("input non valido. Riprova");
                goto SetDelMeseDINascita;

            }
        }

        public static string SetGiornoNascita(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

        SetDelGiornoDINascita:

            // se mese febbraio:
            if (contribuente.Mesenascita == "Febbraio")
            {
                Console.WriteLine("inserisci il giorno di nascita in formato numero: (1/28)");
                Thread.Sleep(2000);
                int giornoDellaNascita = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (giornoDellaNascita >= 1 && giornoDellaNascita <= 28)
                    {
                        Console.WriteLine("Giorno di nascita settato correttamente.");
                        return contribuente.Giornonascita = Convert.ToString(giornoDellaNascita);
                    }
                    else
                    {
                        Console.WriteLine("input non valido. Riprova");
                        goto SetDelGiornoDINascita;
                    }



                }
                catch
                {

                    Console.WriteLine("input non valido. Riprova");
                    goto SetDelGiornoDINascita;

                }
            }
            // mese da 30 giorni
            else if (contribuente.Mesenascita == "Aprile" || contribuente.Mesenascita == "Giugno" || contribuente.Mesenascita == "Settembre" || contribuente.Mesenascita == "Novembre")
            {
                Console.WriteLine("inserisci il giorno di nascita in formato numero: (1/30)");
                Thread.Sleep(2000);
                int giornoDellaNascita = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (giornoDellaNascita >= 1 && giornoDellaNascita <= 30)
                    {
                        Console.WriteLine("Giorno di nascita settato correttamente.");
                        return contribuente.Giornonascita = Convert.ToString(giornoDellaNascita);
                    }
                    else
                    {
                        Console.WriteLine("input non valido. Riprova");
                        goto SetDelGiornoDINascita;
                    }


                }
                catch
                {

                    Console.WriteLine("input non valido. Riprova");
                    goto SetDelGiornoDINascita;

                }
            }
            // mese da 31 giorni
            else
            {
                Console.WriteLine("inserisci il giorno di nascita in formato numero: (1/31)");
                Thread.Sleep(2000);
                int giornoDellaNascita = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (giornoDellaNascita >= 1 && giornoDellaNascita <= 31)
                    {
                        Console.WriteLine("Giorno di nascita settato correttamente.");
                        return contribuente.Giornonascita = Convert.ToString(giornoDellaNascita);
                    }
                    else
                    {
                        Console.WriteLine("input non valido. Riprova");
                        goto SetDelGiornoDINascita;
                    }

                }
                catch
                {

                    Console.WriteLine("input non valido. Riprova");
                    goto SetDelGiornoDINascita;

                }
            }

        }

        public static string SetAnnoDinascita(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

        SetdelAnnoDinascita:
            try
            {
                Console.WriteLine("Inserisci l'anno di nascita: (yyyy)");
                string annoDiNascita = Console.ReadLine();

                if (annoDiNascita.Length != 4 || !int.TryParse(annoDiNascita, out int input))
                {
                    Console.WriteLine("input non valido. Riprova");
                    goto SetdelAnnoDinascita;
                }
                else
                {
                    // ********* controllo del tipo che se eta e data di nascita nn sono coerenti faccio qualcosa? FAI DOPO! *************************
                    Console.WriteLine($"anno di nascita inserito con successo. Il tuo anno di nascita è {annoDiNascita}");
                    return contribuente.AnnoNascita = Convert.ToString(annoDiNascita);
                }

            }
            catch
            {
                Console.WriteLine("input non valido. Riprova");
                goto SetdelAnnoDinascita;
            }
        }

        public static void SetDataNascitaCompleta(Contribuente contribuente)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Finalizzazione data di nascita...");
            contribuente.DataDinascitaCompleta = $"{contribuente.Giornonascita}-{contribuente.Mesenascita}-{contribuente.AnnoNascita}";
            Console.WriteLine($" il contribuente {contribuente.Nome} {contribuente.Cognome} è nato in data {contribuente.DataDinascitaCompleta}");

        }

        public static void SetCodiceFiscale(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

        checkCodicefiscale:
            try
            {
                Console.WriteLine("Inserisci il tuo codice fiscale: (16 caratteri)");
                string codiceFiscale = Console.ReadLine();
                if (codiceFiscale.Length != 16)
                {
                    Console.WriteLine("Attenzione! inserisci un CF di 16 caratteri.");
                    goto checkCodicefiscale;
                }
                else
                {
                    Console.WriteLine("codice fiscale salvato con successo.");
                    contribuente.CodiceFiscale = codiceFiscale;
                }
            }
            catch
            {
                Console.WriteLine("input non valido. Riprova");
                goto checkCodicefiscale;
            }
        }

        public static string SetComunediResidenza(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);
            Console.WriteLine("inserisci il tuo comune di residenza.");
            string comunediresidenza = Console.ReadLine();

            Console.WriteLine("finalizzazione...");
            Thread.Sleep(2000);
            Console.WriteLine("comune di residenza salvato!");
            return contribuente.ComuneDiResidenza = comunediresidenza;

        }

        public static void SetRedditoAnnuale(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

            double redditoAnnuale;

        checkReddito:
            Console.WriteLine("Inserisci il tuo reddito annuale.");

            // Leggi l'input dell'utente come stringa
            string inputReddito = Console.ReadLine();

            // Verifica se l'input dell'utente è un numero
            if (double.TryParse(inputReddito, out redditoAnnuale))
            {
                // Conversione riuscita, l'input è un numero
                contribuente.RedditoAnnuale = redditoAnnuale;
                Console.WriteLine("Reddito annuale inserito con successo.");
            }
            else
            {
                // Conversione non riuscita, l'input non è un numero
                Console.WriteLine("Input non valido. Devi inserire un numero per il reddito annuale.");
                goto checkReddito;
            }
        }

        public static void CalcolotasseImposte(Contribuente contribuente)
        {
            double ImpostaDovuta;

            if (contribuente.RedditoAnnuale < 15000)
            {
                ImpostaDovuta = contribuente.RedditoAnnuale * 23 / 100;
            }
            else if (contribuente.RedditoAnnuale < 28000)
            {
                ImpostaDovuta = 3450 + ((contribuente.RedditoAnnuale - 15000) * 27 / 100);
            }
            else if (contribuente.RedditoAnnuale < 55000)
            {
                ImpostaDovuta = 6960 + ((contribuente.RedditoAnnuale - 28000) * 38 / 100);
            }
            else if (contribuente.RedditoAnnuale < 75000)
            {
                ImpostaDovuta = 17220 + ((contribuente.RedditoAnnuale - 55000) * 41 / 100);
            }
            else if (contribuente.RedditoAnnuale > 75000)
            {
                ImpostaDovuta = 25420 + ((contribuente.RedditoAnnuale - 75900) * 43 / 100);
            }
            else
            {
                Console.WriteLine("Reddito annuale non inserito. Riprova ad inserire");
                Console.WriteLine("Rieffettua il login per effettuare il calcolo.");
                Esci(contribuente);
            }
            //return RedditoAnnualeNetto = RedditoAnnuale - Imposta;
        }

        public static void Esci(Contribuente contribuente)
        {
            Console.WriteLine("Arrivederci!");
            contribuente.RegistrazioneInCorso = false;
        }
    }
}
