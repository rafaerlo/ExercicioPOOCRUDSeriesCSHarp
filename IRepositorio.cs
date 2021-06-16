using System;
using System.Collections.Generic;

namespace SeriesApp
{
	//Interface genérica
	public interface IRepositorio<T>
	{
		List<T> Lista();

		//Assinatura
		T RetornaPorId(int id);

		void Inserir(T entidade);

		void Excluir(int id);

		void Atualiza(int id, T entidade);

		int ProximoID();
	}

}