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
            if (sesso.ToLower() == "m")
            {
                // salva true nel boolean del sesso
                contribuente.IsContribuenteMale = true;
                Console.WriteLine("Abbiamo salvato la tua scelta.");
            }
            else if (sesso.ToLower() == "f")
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
                if (etaUtente <= 0 || etaUtente > 99)
                {
                    Console.WriteLine("Età inserita non Coerente. Riprova");
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
                Console.WriteLine("\n");
                Console.WriteLine($"Benvenuto Nell'Agenzia delle Entrate Sig. {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
            else if ((contribuente.IsContribuenteMale == true && contribuente.Eta < 35))
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Benvenuta Nell'Agenzia delle Entrate Signorino {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
            else if ((contribuente.IsContribuenteMale == false && contribuente.Eta > 35))
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Benvenuto Nell'Agenzia delle Entrate Signora {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
            else if ((contribuente.IsContribuenteMale == false && contribuente.Eta < 35))
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Benvenuto Nell'Agenzia delle Entrate Signorina {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                Menu(contribuente);
            }
        }

        /*
      * summary: menu iniziale, da qui partono le scelte dell utente sul cosa fare, continuare con la registrazione oppure uscire dal programma
      * parametri: viene passato l'intero oggetto contribuente 
      * return: void
      */
        public static void Menu(Contribuente contribuente)
        {
        RipetiMenu:
            Console.WriteLine("\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("A G E N Z I A  D E L L E  E N T R A T E");
            Console.WriteLine("=======================================");
            Console.WriteLine("Scegli cosa Fare:");
            Console.WriteLine("1- Registrati:");
            Console.WriteLine("2- Esci");
            Console.WriteLine("=======================================");
            Console.WriteLine("\n");

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
    * summary: questo metodo raccoglia tutti gli altri metodi il cui scopo è acquisire, attravers unaserie di controlli, i dati dell'utente.
    * parametri: contribuente
    * return: void
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
            CalcoloRedditoAnnualeNetto(contribuente);
            MostraRisultati(contribuente);

        }

        /*
* summary: in questo metodo viene impostato il mese di nascita dell'utente, acquisito come valore numerico e tramite uno switch trasformato in stringa
* parametri: contribuente
* return: string , viene ritornato il valore del mese di nascita a stringa, risultante dallo switch, e salvato come proprietà dell'oggetto. 
*/
        public static string SetMesenascita(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

        // setto il mese: 

        SetDelMeseDINascita:
            Console.WriteLine("\n");
            Console.WriteLine("MESE DI NASCITA:");
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

        /*
* summary: in questo metodo viene impostato il giorno di nascita dell'utente, a seconda di qual'è il mese di nascita viene chiesto di inserire il giorno. Viene tenuto conto se il mese possiedde 28, 30 o 31 giorni.
* parametri: contribuente
* return: void
*/
        public static void SetGiornoNascita(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

        SetDelGiornoDINascita:

            try
            {
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
                            contribuente.Giornonascita = Convert.ToString(giornoDellaNascita);
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
                            contribuente.Giornonascita = Convert.ToString(giornoDellaNascita);
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
                            contribuente.Giornonascita = Convert.ToString(giornoDellaNascita);
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
            catch
            {
                Console.WriteLine("input non valido. Riprova");
                goto SetDelGiornoDINascita;
            }
            // se mese febbraio:


        }

        /*
* summary: in questo metodo viene impostato l'anno di nascita dell'utente, se non riesco a parsare il valore inserito dall utente in un intero significa che sono presenti caratteri letterari nell input e viene chiesto di riprovare.
* parametri: contribuente
* return: string, ritorno la stringa e la assegno alla prop dell'oggetto. "contribuente.AnnoNascita"
*/

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
        /*
* summary: i valori giorno mese e anno di nascita vengono salvati come data di nascita completa.
* parametri: contribuente
* return: void
*/

        public static void SetDataNascitaCompleta(Contribuente contribuente)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Finalizzazione data di nascita...");
            contribuente.DataDinascitaCompleta = $"{contribuente.Giornonascita}-{contribuente.Mesenascita}-{contribuente.AnnoNascita}";
            Console.WriteLine($" il contribuente {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()} è nato in data {contribuente.DataDinascitaCompleta.ToUpper()}");

        }

        /*
* summary: setting del codice fiscale. unico controllo, stringa di lunghezza 16 caratteri.
* parametri: contribuente
* return: void
*/
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

        /*
* summary: setting del comune di residenza. 
* parametri: contribuente
* return: string 
*/

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

        /*
* summary: setting del reddito, se il valore fornito (inputreddito) viene parsato con successo in un doble viene effettuato il setting del reddito annuale del contribuente
* parametri: contribuente
* return: void 
*/
        public static void SetRedditoAnnuale(Contribuente contribuente)
        {
            Console.WriteLine("Attendere...");
            Thread.Sleep(2000);

            double redditoAnnuale;

        checkReddito:
            Console.WriteLine("Inserisci il tuo reddito annuale.");

            string inputReddito = Console.ReadLine();

            if (double.TryParse(inputReddito, out redditoAnnuale))
            {
                contribuente.RedditoAnnuale = redditoAnnuale;
                Console.WriteLine("Reddito annuale inserito con successo.");
            }
            else
            {
                Console.WriteLine("Input non valido. Devi inserire un numero per il reddito annuale.");
                goto checkReddito;
            }
        }

        /*
* summary: in base al reddito salvato (reddito lordo), viene calcolata l'imposta dovuta, vengono salvate nell'oggetto sia il reddito annuale netto che l'imposta dovuta.
* parametri: contribuente
* return: double 
*/

        public static double CalcoloRedditoAnnualeNetto(Contribuente contribuente)
        {
            double ImpostaDovuta;
            double RedditoAnnualeNetto;

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
            else // Reddito annuale superiore a 75000
            {
                ImpostaDovuta = 25420 + ((contribuente.RedditoAnnuale - 75000) * 43 / 100);
            }

            RedditoAnnualeNetto = contribuente.RedditoAnnuale - ImpostaDovuta;
            contribuente.impostaDovuta = ImpostaDovuta;
            return contribuente.redditoAnnualeNetto = RedditoAnnualeNetto;
        }


        /*
* summary: in quest'ultimo metodo vengono mostrate in console i vari dati ottenuti come input dall'utente.
* parametri: contribuente
* return: void 
*/
        public static void MostraRisultati(Contribuente contribuente)
        {

        confermaScelta:
            try
            {

                Console.WriteLine("tutti i dati sono stati inseriti correttamente.");

                Console.WriteLine("Vuoi procedere al calcolo dell'imposta da versare?  y/n");
                string rispostaUtente = Console.ReadLine();

                if (rispostaUtente == "y")
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("C A L C O L O  I M P O S T A  D A  V E R S A R E");
                    Console.WriteLine("===============================================\n");
                    Console.WriteLine($"Contribuente: {contribuente.Nome.ToUpper()} {contribuente.Cognome.ToUpper()}");
                    Console.WriteLine($"Nato il: {contribuente.DataDinascitaCompleta}");
                    Console.WriteLine($"Residente in: {contribuente.ComuneDiResidenza.ToUpper()}");
                    Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale}\n");
                    Console.WriteLine($"Reddito Lordo Dichiarato: {contribuente.RedditoAnnuale}");
                    Console.WriteLine($"IMPOSTA DA VERSARE: {contribuente.impostaDovuta}");
                    Console.WriteLine($"Reddito Netto: {contribuente.redditoAnnualeNetto}\n");




                }
                else if (rispostaUtente == "n")
                {
                    Esci(contribuente);
                }

            }
            catch
            {
                Console.WriteLine("Input non valido. Devi inserire y o n per confermare o annullare l'operazione.");
                goto confermaScelta;
            }


        }
        /*
* summary: metodo di default per chiudere il programma.
* parametri: contribuente
* return: void 
*/
        public static void Esci(Contribuente contribuente)
        {
            Console.WriteLine("Arrivederci!");
            contribuente.RegistrazioneInCorso = false;
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
