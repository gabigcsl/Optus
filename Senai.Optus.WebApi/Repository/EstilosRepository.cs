using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repository
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar (Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilos);
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Estilos categoria)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos CategoriaBuscada = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == categoria.IdEstilo);
                // update categorias set nome = @nome
                CategoriaBuscada.Nome = categoria.Nome;
                // insert - add, delete - remove, update - update
                ctx.Estilos.Update(CategoriaBuscada);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // encontrar o item
                // chave primaria da tabela
                Estilos Categoria = ctx.Estilos.Find(id);
                // remover do contexto
                ctx.Estilos.Remove(Categoria);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }
    }
}
