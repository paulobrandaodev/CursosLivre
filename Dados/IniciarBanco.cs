using System.Linq;
using CursosLivre.Dados;
using CursosLivre.Models;

namespace CursosLivre.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(CursosLivreContexto contexto){
            contexto.Database.EnsureCreated();
        }
    }
}