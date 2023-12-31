﻿using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.manha.Contexts;
using webapi.inlock.dbFirst.manha.Controllers;
using webapi.inlock.dbFirst.manha.Domains;
using webapi.inlock.dbFirst.manha.Interfaces;

namespace webapi.inlock.dbFirst.manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            if (estudioBuscado != null) 
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}