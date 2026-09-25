using System.Reflection.Metadata;

namespace libCptBqTU
{
    public class Compte
    {
        /// <summary>
        /// Propriétés implémentées automatiquement
        /// </summary>
        public int Numero { get; set; }
        public string Nom { get; set; }
        public decimal Solde { get; set; }
        public decimal DecouvertAutorise { get; set; }


        /// <summary>
        /// Constructeur à 4 arguments
        /// </summary>
        /// <param name="numero">le numéro</param>
        /// <param name="nom">le nom</param>
        /// <param name="solde">le solde</param>
        /// <param name="decouvertAutorise">le découvert autorisé</param>
        public Compte(int numero, string nom, decimal solde, decimal decouvertAutorise)
        {
            Numero = numero;
            Nom = nom;
            Solde = solde;
            DecouvertAutorise = decouvertAutorise;

        }
        /// <summary>
        /// Constructeur de compte par défaut
        /// </summary>
        public Compte()
        {
            Numero = 0;
            Nom = "";
            Solde = 0;
            DecouvertAutorise = 0;

        }
        /// <summary>
        /// Réecriture de la méthode ToString
        /// </summary>
        public override string ToString()
        {
            return $"numero: {Numero} nom: {Nom} solde: {Solde:0.00} decouvert autorisé: {DecouvertAutorise:0.00}";
        }

        /// <returns></returns


        /// <summary>
        /// Crédite le compte du montant spécifié
        /// </summary>
        public void Crediter(decimal montant)
        {
            if (montant >= 0)
            { Solde = Solde + montant; }
        }

        /// <param name="montant">Le montant à créditer</param>



        /// <summary>
        /// Débite le compte du montant spécifié si le solde le permet
        /// </summary>
        public bool Debiter(decimal montant)
        {
            if (montant <= 0)
            {
                return false;
            }

            if (Solde - montant >= DecouvertAutorise)
            {
                Solde = Solde - montant;
                return true;
            }

            return false;
        }



        /// <param name="montant">Le montant à débiter</param>
        /// <returns>True si le débit a été effectué, False sinon</returns>



        /// <summary>
        /// Transférer un montant vers un autre compte
        /// </summary>
        public bool Transferer(decimal montant, Compte compteDestination)
        {
            if (montant <= 0)
            {
                return false;
            }
            if (Debiter(montant))
            {
                compteDestination.Crediter(montant);
                return true;
            }
            return false;
        }

        /// <param name="montant"></param>
        /// <param name="compteDestination"></param>
        /// <returns></returns>



        /// <summary>
        /// Savoir si le solde est supérieur à celui d'un autre compte
        /// </summary>
        public bool Superieur(Compte compteDestination)
        {
            if (Solde > compteDestination.Solde)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <param name="compteDestination"></param>
        /// <returns></returns>

    }

    public class Banque
    {
        private List<Compte> mesComptes;
        private List<Type> mesTypes;
            
        public Banque()
        {
            mesComptes = new List<Compte>();
            mesTypes = new List<Type>();
        }
        // l'attribut de la classe banque est mesComptes
        // mesComptes contient la liste de tout les comptes de la banque

    
        //Methode 1: Ajouter un objet Compte existant
    public void AjouterCompte(Compte c)
        {
            mesComptes.Add(c);
        }

        //Methode 2: Creer et ajouter un compte directement via ses parametres
        public void AjouterCompte(int numero, string nom, decimal solde, decimal decouvert)
        {
            Compte c = new Compte(numero, nom, solde, decouvert);
            mesComptes.Add(c);
        }
    }
}