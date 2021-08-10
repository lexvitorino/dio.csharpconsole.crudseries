using System.Collections.Generic;
using MI7Dev.Series.Interfaces;

namespace MI7Dev.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id-1] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id-1].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count + 1;
		}

		public Serie RetornaPorId(int id)
		{
			try
			{
				return listaSerie[id-1];
			}
			catch (System.Exception)
			{
				return null;
			}
		}
	}
}