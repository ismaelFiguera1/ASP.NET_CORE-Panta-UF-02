using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Repository.interfaces;
using System.Collections.Generic;

namespace Cistell_de_la_compra.Repository
{
    public class UsuarisRepository : IUsuarisRepository
	{




		public List<Usuari> ObtenirTotsUsuaris()
		{
			return Usuaris._usuaris;
		}

		public Dictionary<string, int> obtenirNumeroIntents()
		{
			return Usuaris.numeroIntents;
		}

		public (Usuari, string) trobar(string email, string password)
		{
			UsuarisRepository ur = new();
			var llista = ur.ObtenirTotsUsuaris();
			foreach (var item in llista)
			{
				if (item.email == email)
				{

					if (item.password == password)
					{
						Dictionary<string, int> llistaIntents = ur.obtenirNumeroIntents();
						foreach (var item1 in llistaIntents)
						{
							if (item1.Value >= 3 && item1.Key == email)
							{
								item.locked = true;
								return (null, "ERROR    USUARI    BLOQUEJAT");
							}
						}
						return (item, null);
					}
				}
			}

			return (null, null);
		}

		public bool comprovarCorreu(string email)
		{
			UsuarisRepository ur = new();

			var llistaUsuaris = ur.ObtenirTotsUsuaris();

			foreach (var item in llistaUsuaris)
			{
				if (item.email == email)
				{
					return true;
				}
			}


			return false;
		}

		public void controlIntents(bool correuCorrecte, string correu)
		{
			if (correuCorrecte)
			{
				UsuarisRepository ur = new UsuarisRepository();
				Dictionary<string, int> diccionari = ur.obtenirNumeroIntents();
				foreach (var item in diccionari)
				{
					if (item.Key == correu)
					{
						diccionari[item.Key]++;
					}
				}
			}

		}

		public void esborrarIntents(Usuari user)
		{
			UsuarisRepository ur = new();
			Dictionary<string, int> intents = ur.obtenirNumeroIntents();
			foreach (var item in intents)
			{
				if (item.Key == user.email)
				{
					intents[item.Key] = 0;
				}
			}
		}
	}
}
